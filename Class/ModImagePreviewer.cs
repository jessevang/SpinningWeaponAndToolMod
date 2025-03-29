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
        private enum PreviewState { SelectMod, SelectImage, Preview }
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
        private static string selectedMod;
        private static string selectedImage;
        private static Texture2D texture;

        private static int tileWidth = 16;
        private static int tileHeight = 16;
        private static PreviewState state = PreviewState.SelectMod;
        public static ModEntry Instance { get; set; }
        public static ModConfig Config { get; set; }

        public static void Open()
        {
            modIds = ModEntry.Instance.Helper.ModRegistry.GetAll().Select(m => m.Manifest.UniqueID).OrderBy(s => s).ToList();
            state = PreviewState.SelectMod;
            
            Game1.activeClickableMenu = new ModImagePreviewer(Instance, Config);
        }


        public ModImagePreviewer(ModEntry instance, ModConfig config)
        {
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
            int listCount = state == PreviewState.SelectMod ? modIds.Count : imagePaths.Count;

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
                case PreviewState.SelectMod:
                    DrawModSelection(b);
                    break;
                case PreviewState.SelectImage:
                    DrawImageSelection(b);
                    break;
                case PreviewState.Preview:
                    DrawImagePreview(b);
                    break;
            }

            // Draw Back button
            if (state != PreviewState.SelectMod)
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
                int listCount = state == PreviewState.SelectMod ? modIds.Count : imagePaths.Count;
                scrollOffset = Math.Min(listCount - maxVisibleItems, scrollOffset + 1);
                return;
            }
            else if (scrollBar.containsPoint(x, y))
            {
                scrolling = true;
                return;
            }

            base.receiveLeftClick(x, y, playSound);
            int yOffset = 100;

            // Handle Back button in any state except SelectMod
            if (state != PreviewState.SelectMod && backButtonRect.Contains(x, y))
            {
                if (state == PreviewState.SelectImage)
                {
                    state = PreviewState.SelectMod;
                    scrollOffset = 0;
                }
                else if (state == PreviewState.Preview)
                {
                    state = PreviewState.SelectImage;
                    scrollOffset = 0;
                }
                return;
            }

            switch (state)
            {
                case PreviewState.SelectMod:
                    int modStart = scrollOffset;
                    int modEnd = Math.Min(modIds.Count, scrollOffset + maxVisibleItems);
                    for (int i = modStart; i < modEnd; i++)
                    {
                        int drawY = yOffset + (i - scrollOffset) * itemHeight;
                        Rectangle clickable = new Rectangle(200, drawY, 600, 36);
                        if (clickable.Contains(x, y))
                        {
                            selectedMod = modIds[i];
                            var modInfo = ModEntry.Instance.Helper.ModRegistry.Get(selectedMod);
                            var dir = modInfo?.GetType().GetProperty("DirectoryPath")?.GetValue(modInfo) as string;
                            imagePaths = Directory.GetFiles(dir, "*.png", SearchOption.AllDirectories)
                                .Select(p => Path.GetRelativePath(dir, p).Replace("\\", "/"))
                                .OrderBy(s => s).ToList();
                            scrollOffset = 0;
                            state = PreviewState.SelectImage;
                            return;
                        }
                    }
                    break;

                case PreviewState.SelectImage:
                    int imgStart = scrollOffset;
                    int imgEnd = Math.Min(imagePaths.Count, scrollOffset + maxVisibleItems);
                    for (int i = imgStart; i < imgEnd; i++)
                    {
                        int drawY = yOffset + (i - scrollOffset) * itemHeight;
                        Rectangle clickable = new Rectangle(200, drawY, 600, 36);
                        if (clickable.Contains(x, y))
                        {
                            selectedImage = imagePaths[i];

                            try
                            {
                                var modInfo = ModEntry.Instance.Helper.ModRegistry.Get(selectedMod);
                                var dir = modInfo?.GetType().GetProperty("DirectoryPath")?.GetValue(modInfo) as string;
                                string fullImagePath = Path.Combine(dir, selectedImage);

                                using (FileStream stream = new FileStream(fullImagePath, FileMode.Open, FileAccess.Read))
                                {
                                    texture = Texture2D.FromStream(Game1.graphics.GraphicsDevice, stream);
                                }

                                scrollOffset = 0;
                                state = PreviewState.Preview;
                            }
                            catch (Exception ex)
                            {
                                Game1.addHUDMessage(new HUDMessage("Failed to load image: " + ex.Message, 3));
                                ModEntry.Instance.Monitor.Log($"Error loading texture from mod '{selectedMod}': {ex}", LogLevel.Error);
                            }
                            return;
                        }
                    }
                    break;

                case PreviewState.Preview:
                    {
                        if (lastHoveredSourceRect is not Rectangle rect)
                        {
                            Game1.addHUDMessage(new HUDMessage("No tile selected", HUDMessage.error_type));
                            return;
                        }

                        string selectedModID = selectedMod;
                        var modInfo = ModEntry.Instance.Helper.ModRegistry.Get(selectedModID);
                        string sourceModDir = modInfo?.GetType()?.GetProperty("DirectoryPath")?.GetValue(modInfo) as string;

                        string myModID = ModEntry.Instance.ModManifest.UniqueID;
                        string myModAssets = Path.Combine(ModEntry.Instance.Helper.DirectoryPath, "assets");

                        string copiedPathForConfig;
                        string? copiedFullPath = null;
                        string? modIdForConfig = null;

                        if (selectedModID == myModID)
                        {
                            // From current mod: no copy or rename
                            copiedPathForConfig = selectedImage;
                        }
                        else
                        {
                            string filename = Path.GetFileNameWithoutExtension(selectedImage);
                            string newFilename = $"{filename}.png";
                            copiedPathForConfig = $"assets/{newFilename}";
                            copiedFullPath = Path.Combine(myModAssets, newFilename);
                            modIdForConfig = selectedModID;

                            if (!File.Exists(copiedFullPath))
                            {
                                try
                                {
                                    Directory.CreateDirectory(myModAssets);
                                    string fullSourcePath = Path.Combine(sourceModDir, selectedImage);
                                    File.Copy(fullSourcePath, copiedFullPath, overwrite: false);
                                    ModEntry.Instance.Monitor.Log($"Copied {selectedImage} to assets folder as {newFilename}", LogLevel.Info);
                                }
                                catch (Exception ex)
                                {
                                    ModEntry.Instance.Monitor.Log($"Failed to copy image from {selectedImage}: {ex}", LogLevel.Error);
                                }
                            }
                        }

                        // Create WeaponSpriteData entry
                        string itemName = Game1.player.CurrentItem?.DisplayName ?? "Unknown";
                        string itemID = Game1.player.CurrentItem?.ItemId ?? "0";
                        string itemTypeID = Game1.player.CurrentItem?.GetItemTypeId() ?? "W";

                        WeaponSpriteData newEntry = new()
                        {
                            ModID = modIdForConfig,
                            ItemName = itemName,
                            itemCategoryAndItemID = itemTypeID + itemID,
                            tilesheetName = copiedPathForConfig,
                            fullPath = copiedFullPath,
                            SourceRect = rect
                        };

                        // Replace existing entry and write config
                        Config.weaponSpriteData.RemoveAll(w => w.itemCategoryAndItemID == newEntry.itemCategoryAndItemID);
                        Config.weaponSpriteData.Add(newEntry);
                        ModEntry.Instance.Helper.WriteConfig(Config);

                        Game1.addHUDMessage(new HUDMessage("Sprite saved and image registered!", HUDMessage.newQuest_type));
                        Game1.activeClickableMenu = null; // Exit the menu
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
