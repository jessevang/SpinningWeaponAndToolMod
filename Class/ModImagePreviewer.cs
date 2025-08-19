using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.BellsAndWhistles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StardewValley.GameData.Pets;
using Microsoft.Xna.Framework.Input;

namespace SpinningWeaponAndToolMod
{
    public class ModImagePreviewer : IClickableMenu
    {


        private static Rectangle backButtonRect = new Rectangle(50, 50, 120, 60);
        private int scrollOffset = 0;
        private int maxVisibleItems = 10; // How many items can be shown before scrolling
        private const int itemHeight = 40;
        private static readonly Dictionary<string, Texture2D> _cachedTextures = new();
        private ClickableTextureComponent upArrow;
        private ClickableTextureComponent downArrow;
        private ClickableTextureComponent scrollBar;
        private Rectangle scrollBarRunner;

        private Rectangle? lastHoveredSourceRect = null;
        private bool scrolling = false;
        private static List<string> modIds;
        private static List<string> imagePaths;
        private static string? selectedMod; 
        private static string selectedImage;
        private static Texture2D texture;

        private static int tileWidth = 16;
        private static int tileHeight = 16;
        private static PreviewState state = PreviewState.SelectSource;

        public static ModEntry Instance { get; set; }
        public static ModConfig Config { get; set; }
        public static ITranslationHelper i18n;
        private static List<string> assetNames; // derived from VanillaAssetHints for the picker


        private enum PreviewState { SelectSource, SelectMod, SelectImage, SelectGameAsset, Preview }
        private enum SourceMode { ModPng, GameAsset }
        private static SourceMode currentSource = SourceMode.ModPng;

        public static void Open()
        {
            modIds = ModEntry.Instance.Helper.ModRegistry.GetAll()
                .Select(m => m.Manifest.UniqueID)
                .OrderBy(s => s)
                .ToList();


            assetNames = VanillaAssetHints.Select(v => v.assetName)
                .OrderBy(s => s)
                .ToList();

            state = PreviewState.SelectSource;
            Game1.activeClickableMenu = new ModImagePreviewer(Instance, Config, i18n);
        }





        private void DrawSourceSelection(SpriteBatch b)
        {
            SpriteText.drawString(b, "Choose Source:", 200, 50);


            var modBtn = new Rectangle(200, 120, 360, 60);
            var assetBtn = new Rectangle(200, 200, 360, 60);

            IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60), modBtn.X, modBtn.Y, modBtn.Width, modBtn.Height, Color.White);
            IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60), assetBtn.X, assetBtn.Y, assetBtn.Width, assetBtn.Height, Color.White);

            SpriteText.drawString(b, "Mod PNGs", modBtn.X + 20, modBtn.Y + 16);
            SpriteText.drawString(b, "Stardew Valley Assets", assetBtn.X + 20, assetBtn.Y + 16);
        }


        // Built-in common vanilla assets + default tile sizes for your grid
        private static readonly (string assetName, int tw, int th, string note)[] VanillaAssetHints = new[]
        {
            ("LooseSprites/Cursors", 16, 16, "UI, tools, many icons"),
            ("TileSheets/weapons", 16, 16, "Weapon icons"),
            ("TileSheets/tools", 16, 16, "Tool icons"),
            ("TileSheets/Crops", 16, 16, "Crop tiles"),
            ("Maps/springobjects", 16, 16, "Object icons"),
            ("Characters/Farmer", 16, 32, "Farmer base frames"),
            ("TileSheets/BuffsIcons", 16, 16, "Buff icons")
        };



        private void DrawGameAssetSelection(SpriteBatch b)
        {
            SpriteText.drawString(b, "Select a Game Asset:", 200, 50);

            // safety: ensure list is ready
            if (assetNames == null || assetNames.Count == 0)
            {
                assetNames = VanillaAssetHints.Select(v => v.assetName).OrderBy(s => s).ToList();
                if (assetNames.Count == 0)
                {
                    SpriteText.drawString(b, "(No assets to show)", 200, 100);
                    return;
                }
            }

            // clamp + draw
            scrollOffset = Math.Max(0, Math.Min(scrollOffset, Math.Max(0, assetNames.Count - maxVisibleItems)));
            int start = scrollOffset;
            int end = Math.Min(assetNames.Count, scrollOffset + maxVisibleItems);

            for (int i = start; i < end; i++)
            {
                int y = 100 + (i - scrollOffset) * itemHeight;
                var hint = VanillaAssetHints.FirstOrDefault(v => v.assetName == assetNames[i]);
                string line = hint.assetName + (string.IsNullOrEmpty(hint.note) ? "" : $"  — {hint.note}");
                SpriteText.drawString(b, line, 200, y);
            }

            DrawScrollBar(b, assetNames.Count);
        }





        // Helper to load a game asset as a Texture2D
        private bool TryLoadGameAssetTexture(string assetName, out Texture2D tex)
        {
            try
            {
                tex = Instance.Helper.GameContent.Load<Texture2D>(assetName);
                return true;
            }
            catch (Exception ex)
            {
                tex = null!;
                Instance.Monitor.Log($"Failed to load game asset '{assetName}': {ex}", LogLevel.Warn);
                return false;
            }
        }

        public ModImagePreviewer(ModEntry instance, ModConfig config, ITranslationHelper i18nn)
        {
            i18n = i18nn;
            Config = config;
            Instance = instance;
            populateModList();

            this.width = Game1.viewport.Width;
            this.height = Game1.viewport.Height;
            this.xPositionOnScreen = 0;
            this.yPositionOnScreen = 0;
            int scrollbarX = Game1.viewport.Width - 120;
            int scrollbarY = 100;
            int scrollbarHeight = itemHeight * maxVisibleItems;

            upArrow = new ClickableTextureComponent("up-arrow", new Rectangle(scrollbarX, scrollbarY - 32, 44, 48), null, "", Game1.mouseCursors, new Rectangle(421, 459, 11, 12), 4f);
            downArrow = new ClickableTextureComponent("down-arrow", new Rectangle(scrollbarX, scrollbarY + scrollbarHeight, 44, 48), null, "", Game1.mouseCursors, new Rectangle(421, 472, 11, 12), 4f);
            scrollBar = new ClickableTextureComponent("scrollbar", new Rectangle(scrollbarX + 12, scrollbarY, 24, 40), null, "", Game1.mouseCursors, new Rectangle(435, 463, 6, 10), 4f);
            scrollBarRunner = new Rectangle(scrollbarX + 12, scrollbarY, 24, scrollbarHeight);


        }

        public override void receiveScrollWheelAction(int direction)
        {
            base.receiveScrollWheelAction(direction);

            int listCount =
                state == PreviewState.SelectMod ? modIds.Count :
                state == PreviewState.SelectImage ? imagePaths.Count :
                state == PreviewState.SelectGameAsset ? (assetNames?.Count ?? 0) :
                0;

            if (listCount <= 0) return;

            if (direction > 0)
                scrollOffset = Math.Max(0, scrollOffset - 1);
            else if (direction < 0)
                scrollOffset = Math.Min(Math.Max(0, listCount - maxVisibleItems), scrollOffset + 1);
        }


        private void UpdateScrollBarLayout()
        {
            int scrollbarX = Game1.viewport.Width - 120;
            int scrollbarY = 100;
            int scrollbarHeight = itemHeight * maxVisibleItems;

            scrollBarRunner = new Rectangle(scrollbarX + 12, scrollbarY, 24, scrollbarHeight);
            upArrow.bounds = new Rectangle(scrollbarX, scrollbarY - 32, 44, 48);
            downArrow.bounds = new Rectangle(scrollbarX, scrollbarY + scrollbarHeight, 44, 48);
            scrollBar.bounds = new Rectangle(scrollbarX + 12, scrollBar.bounds.Y, 24, 40);
        }



        public override void draw(SpriteBatch b)
        {
            base.draw(b);




            // Draw background
            IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60),
                180, 40, Game1.viewport.Width - 360, Game1.viewport.Height - 80, Color.White, 1f, false);

            // Draw main content
            switch (state)
            {
                case PreviewState.SelectSource:
                    DrawSourceSelection(b);
                    break;
                case PreviewState.SelectMod:
                    DrawModSelection(b);
                    break;
                case PreviewState.SelectImage:
                    DrawImageSelection(b);
                    break;
                case PreviewState.SelectGameAsset:
                    DrawGameAssetSelection(b);
                    break;
                case PreviewState.Preview:
                    DrawImagePreview(b);
                    break;
            }


            // Draw Back button
            if (state != PreviewState.SelectSource)
                DrawBackButton(b);


            // Draw toolbar on top
            Game1.onScreenMenus.OfType<Toolbar>().FirstOrDefault()?.draw(b);
            UpdateScrollBarLayout();
            drawMouse(b);
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            // Handle scrollbar input
            if (upArrow.containsPoint(x, y))
            {
                scrollOffset = Math.Max(0, scrollOffset - 1);
                return;
            }
            else if (downArrow.containsPoint(x, y))
            {
                int listCount =
                    state == PreviewState.SelectMod ? modIds.Count :
                    state == PreviewState.SelectImage ? imagePaths.Count :
                    state == PreviewState.SelectGameAsset ? assetNames.Count :
                    0;

                scrollOffset = Math.Min(Math.Max(0, listCount - maxVisibleItems), scrollOffset + 1);
                return;
            }
            else if (scrollBar.containsPoint(x, y))
            {
                scrolling = true;
                return;
            }

            base.receiveLeftClick(x, y, playSound);
            int yOffset = 100; 

            if (state != PreviewState.SelectSource && backButtonRect.Contains(x, y))
            {
                if (state == PreviewState.SelectMod || state == PreviewState.SelectGameAsset)
                {
                    state = PreviewState.SelectSource;
                    scrollOffset = 0;
                }
                else if (state == PreviewState.SelectImage)
                {
                    state = PreviewState.SelectMod;
                    scrollOffset = 0;
                }
                else if (state == PreviewState.Preview)
                {
                    state = (currentSource == SourceMode.ModPng)
                        ? PreviewState.SelectImage
                        : PreviewState.SelectGameAsset;
                    scrollOffset = 0;
                }
                return;
            }

            switch (state)
            {
                case PreviewState.SelectSource:
                    {
                        var modBtn = new Rectangle(200, 120, 360, 60);
                        var assetBtn = new Rectangle(200, 200, 360, 60);

                        if (modBtn.Contains(x, y))
                        {
                            currentSource = SourceMode.ModPng;
                            state = PreviewState.SelectMod;
                            scrollOffset = 0;
                            return;
                        }
                        if (assetBtn.Contains(x, y))
                        {
                            currentSource = SourceMode.GameAsset;
                            state = PreviewState.SelectGameAsset;
                            scrollOffset = 0;
                            return;
                        }
                        break;
                    }

                case PreviewState.SelectGameAsset:
                    {
                        int start = scrollOffset;
                        int end = Math.Min(assetNames.Count, scrollOffset + maxVisibleItems);
                        for (int i = start; i < end; i++)
                        {
                            int drawY = yOffset + (i - scrollOffset) * itemHeight;
                            Rectangle clickable = new Rectangle(200, drawY, 900, 36);
                            if (clickable.Contains(x, y))
                            {
                                string chosen = assetNames[i];


                                var hint = VanillaAssetHints.FirstOrDefault(v => v.assetName == chosen);
                                tileWidth = (hint.tw > 0) ? hint.tw : 16;
                                tileHeight = (hint.th > 0) ? hint.th : 16;

                                if (TryLoadGameAssetTexture(chosen, out var tex))
                                {
                                    texture = tex;
                                    selectedMod = null;   
                                    selectedImage = chosen;  
                                    state = PreviewState.Preview;
                                    scrollOffset = 0;
                                }
                                else
                                {
                                    Game1.addHUDMessage(new HUDMessage($"Couldn't load asset: {chosen}", HUDMessage.error_type));
                                }
                                return;
                            }
                        }
                        break;
                    }


                case PreviewState.Preview:
                    {
                        if (lastHoveredSourceRect is not Rectangle rect)
                        {
                            Game1.addHUDMessage(new HUDMessage(i18n.Get("ModImagePreviewer.Cs-AddHudMessage.NoTileSelected"), HUDMessage.error_type));
                            return;
                        }


                        string itemName = Game1.player.CurrentItem?.DisplayName ?? "Unknown";
                        string itemID = Game1.player.CurrentItem?.ItemId ?? "0";
                        string itemTypeID = Game1.player.CurrentItem?.GetItemTypeId() ?? "W";

                        string? modIdForConfig = null;
                        string tilesheetForConfig;
                        string? fullPathForConfig = null;

                        if (currentSource == SourceMode.GameAsset)
                        {
                            tilesheetForConfig = selectedImage;
                        }
                        else
                        {

                            string selectedModID = selectedMod;
                            var modInfo = ModEntry.Instance.Helper.ModRegistry.Get(selectedModID);
                            string sourceModDir = modInfo?.GetType()?.GetProperty("DirectoryPath")?.GetValue(modInfo) as string;

                            string myModID = ModEntry.Instance.ModManifest.UniqueID;
                            string myModAssets = Path.Combine(ModEntry.Instance.Helper.DirectoryPath, "assets");

                            if (selectedModID == myModID)
                            {
                                tilesheetForConfig = selectedImage;
                            }
                            else
                            {
                                string filename = Path.GetFileNameWithoutExtension(selectedImage);
                                string newFilename = $"{filename}.png";
                                tilesheetForConfig = $"assets/{newFilename}";
                                fullPathForConfig = Path.Combine(myModAssets, newFilename);
                                modIdForConfig = selectedModID;

                                if (!File.Exists(fullPathForConfig))
                                {
                                    try
                                    {
                                        Directory.CreateDirectory(myModAssets);
                                        string fullSourcePath = Path.Combine(sourceModDir, selectedImage);
                                        File.Copy(fullSourcePath, fullPathForConfig, overwrite: false);
                                    }
                                    catch (Exception ex)
                                    {
                                        ModEntry.Instance.Monitor.Log($"Failed to copy image from {selectedImage}: {ex}", LogLevel.Error);
                                    }
                                }
                            }
                        }

                        // Save entry
                        WeaponSpriteData newEntry = new()
                        {
                            ModID = (currentSource == SourceMode.GameAsset) ? null : modIdForConfig,
                            ItemName = itemName,
                            itemCategoryAndItemID = itemTypeID + itemID,
                            tilesheetName = tilesheetForConfig,
                            fullPath = fullPathForConfig,
                            SourceRect = rect
                        };

                        Config.weaponSpriteData.RemoveAll(w => w.itemCategoryAndItemID == newEntry.itemCategoryAndItemID);
                        Config.weaponSpriteData.Add(newEntry);
                        ModEntry.Instance.Helper.WriteConfig(Config);

                        Game1.addHUDMessage(new HUDMessage(i18n.Get("ModImagePreviewer.Cs-AddHudMessage.SpriteSaved"), HUDMessage.newQuest_type));
                        Game1.activeClickableMenu = null;
                        return;
                    }
            }
        }




        private void DrawModSelection(SpriteBatch b)
        {
            SpriteText.drawString(b, "Select a Mod:", 200, 50);

            // Clamp scrollOffset safely
            scrollOffset = Math.Max(0, Math.Min(scrollOffset, Math.Max(0, modIds.Count - maxVisibleItems)));
            int start = scrollOffset;
            int end = Math.Min(modIds.Count, scrollOffset + maxVisibleItems);

            for (int i = start; i < end; i++)
            {
                int y = 100 + (i - scrollOffset) * itemHeight;
                SpriteText.drawString(b, modIds[i], 200, y);
            }

            DrawScrollBar(b, modIds.Count);
        }


        private void DrawScrollBar(SpriteBatch b, int totalItems)
        {
            if (totalItems <= maxVisibleItems)
                return; // No scrollbar needed

            // Draw arrows
            upArrow.draw(b);
            downArrow.draw(b);

            // Scrollbar background
            IClickableMenu.drawTextureBox(
                b,
                Game1.menuTexture,
                new Rectangle(0, 256, 60, 60),
                scrollBarRunner.X,
                scrollBarRunner.Y,
                scrollBarRunner.Width,
                scrollBarRunner.Height,
                Color.White
            );

            // Scrollbar thumb position
            float scrollRatio = (float)scrollOffset / Math.Max(1, totalItems - maxVisibleItems);
            int thumbHeight = 40;
            int trackHeight = scrollBarRunner.Height - thumbHeight;
            int thumbY = scrollBarRunner.Y + (int)(scrollRatio * trackHeight);

            scrollBar.bounds.Y = thumbY;
            scrollBar.draw(b);
        }




        private void DrawImageSelection(SpriteBatch b)
        {
            SpriteText.drawString(b, $"Mod: {selectedMod}", 200, 50);

            scrollOffset = Math.Max(0, Math.Min(scrollOffset, Math.Max(0, imagePaths.Count - maxVisibleItems)));
            int start = scrollOffset;
            int end = Math.Min(imagePaths.Count, scrollOffset + maxVisibleItems);

            for (int i = start; i < end; i++)
            {
                int y = 100 + (i - scrollOffset) * itemHeight;
                SpriteText.drawString(b, imagePaths[i], 200, y);
            }

            DrawScrollBar(b, imagePaths.Count);
        }


        private void DrawImagePreview(SpriteBatch b)
        {
            // Calculate scale to fit image in screen
            float scale = Math.Min(
                (float)(Game1.uiViewport.Width - 200) / texture.Width,
                (float)(Game1.uiViewport.Height - 200) / texture.Height
            );

            width = (int)(texture.Width * scale);
            height = (int)(texture.Height * scale);
            xPositionOnScreen = (Game1.uiViewport.Width - width) / 2;
            yPositionOnScreen = (Game1.uiViewport.Height - height) / 2;

            // Draw scaled texture
            b.Draw(texture, new Rectangle(xPositionOnScreen, yPositionOnScreen, width, height), Color.White);

            // Draw tile grid
            int tilesX = texture.Width / tileWidth;
            int tilesY = texture.Height / tileHeight;
            for (int x = 0; x < tilesX; x++)
            {
                for (int y = 0; y < tilesY; y++)
                {
                    int gridX = xPositionOnScreen + (int)(x * tileWidth * scale);
                    int gridY = yPositionOnScreen + (int)(y * tileHeight * scale);
                    b.Draw(Game1.staminaRect, new Rectangle(gridX, gridY, (int)(tileWidth * scale), 1), Color.Red * 0.5f);
                    b.Draw(Game1.staminaRect, new Rectangle(gridX, gridY, 1, (int)(tileHeight * scale)), Color.Red * 0.5f);
                }
            }

            // Draw hover info
            Vector2 mouse = Game1.getMousePosition().ToVector2();
            if (mouse.X >= xPositionOnScreen && mouse.X < xPositionOnScreen + width &&
                mouse.Y >= yPositionOnScreen && mouse.Y < yPositionOnScreen + height)
            {
                int tileX = (int)((mouse.X - xPositionOnScreen) / (tileWidth * scale));
                int tileY = (int)((mouse.Y - yPositionOnScreen) / (tileHeight * scale));
                int srcX = tileX * tileWidth;
                int srcY = tileY * tileHeight;
                lastHoveredSourceRect = new Rectangle(srcX, srcY, tileWidth, tileHeight);
                String ItemID = Game1.player.CurrentItem.ItemId;
                String ItemName = Game1.player.CurrentItem.Name;
                String ItemTypeID = Game1.player.CurrentItem.GetItemTypeId();
                string rectItemInfo = $"{ItemName}: {ItemTypeID}{ItemID}";
                string rectInfo = $"SourceRect: X={srcX}, Y={srcY}, Width={tileWidth}, Height={tileHeight}";
                b.DrawString(Game1.smallFont, rectItemInfo, new Vector2(xPositionOnScreen - 40, yPositionOnScreen + height - 20), Color.DarkBlue, 0f, Vector2.Zero, 0.95f, SpriteEffects.None, 1f);
                b.DrawString(Game1.smallFont, rectInfo, new Vector2(xPositionOnScreen - 40, yPositionOnScreen + height+10), Color.Black, 0f, Vector2.Zero, 0.95f, SpriteEffects.None, 1f);



            }

            
        }



        private void populateModList()
        {
            modIds = ModEntry.Instance.Helper.ModRegistry.GetAll()
                .Where(m => !string.IsNullOrEmpty(m.Manifest.UniqueID))
                .Select(m => m.Manifest.UniqueID)
                .OrderBy(id => id)
                .ToList();
        }



        private void DrawBackButton(SpriteBatch b)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(403, 383, 6, 6),
                backButtonRect.X, backButtonRect.Y, backButtonRect.Width, backButtonRect.Height, Color.White, 4f);
            SpriteText.drawString(b, "Back", backButtonRect.X + 20, backButtonRect.Y + 10);
        }


    }
}
