// All using directives stay the same
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Tools;
using Microsoft.Xna.Framework;
using StardewValley.Monsters;
using StardewValley.TerrainFeatures;
using GenericModConfigMenu;
using Microsoft.Xna.Framework.Graphics;


namespace SpinningWeaponAndToolMod
{
    public class ModConfig
    {
        public SButton SpinHotkey { get; set; } = SButton.MouseRight;
        public SButton SpinHotkeyController { get; set; } = SButton.ControllerX;
        public float BaseStaminaDrain { get; set; } = 3.0f;
        public float reduceStaminaDrainForWeaponsPerLevel = 0.1f;
        public float reduceStaminaDrainForAxePerLevel = 0.1f;
        public float reduceStaminaDrainForPickaxePerLevel = 0.1f;
        public int weaponSpinRadius { get; set; } = 2;
        public float weaponSpinPercentDamage { get; set; } = 1.0f;
        public int numberOfWeaponSpinHitsPerSecond { get; set; } = 3;
        public int axeSpinRadius { get; set; } = 2;
        public int numberOfAxeSpinHitsPerSecond { get; set; } = 2;
        public int pickaxeSpinRadius { get; set; } = 2;
        public int numberOfPickaxeSpinHitsPerSecond { get; set; } = 2;
        public int numberOfSpinningSprite {   get; set; } = 5;

        public string note { get; set; } = "Feel free add your weapon sprite or update existing one if you want custom mod sprites for weapons or tools to appear when using/tools the spin attack";
        public List<WeaponSpriteData> weaponSpriteData { get; set; } = new List<WeaponSpriteData>
        {

            new WeaponSpriteData{ItemName= "Rusty Sword", itemCategoryAndItemID = "(W)0", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,0,16,16)},
            new WeaponSpriteData{ItemName= "Silver Saber", itemCategoryAndItemID = "(W)1", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,0,16,16)},
            new WeaponSpriteData{ItemName= "Dark Sword", itemCategoryAndItemID = "(W)2", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,0,16,16)},
            new WeaponSpriteData{ItemName= "Holy Blade", itemCategoryAndItemID = "(W)3", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,0,16,16)},
            new WeaponSpriteData{ItemName= "Galaxy Sword", itemCategoryAndItemID = "(W)4", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,0,16,16)},
            new WeaponSpriteData{ItemName= "Bone Sword", itemCategoryAndItemID = "(W)5", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,0,16,16)},
            new WeaponSpriteData{ItemName= "Iron Edge", itemCategoryAndItemID = "(W)6", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,0,16,16)},
            new WeaponSpriteData{ItemName= "Templar's Blade", itemCategoryAndItemID = "(W)7", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,0,16,16)},
            new WeaponSpriteData{ItemName= "Obsidian Edge", itemCategoryAndItemID = "(W)8", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,16,16,16)},
            new WeaponSpriteData{ItemName= "Lava Katana", itemCategoryAndItemID = "(W)9", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,16,16,16)},
            new WeaponSpriteData{ItemName= "Claymore", itemCategoryAndItemID = "(W)10", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,16,16,16)},
            new WeaponSpriteData{ItemName= "Steel Smallsword", itemCategoryAndItemID = "(W)11", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,16,16,16)},
            new WeaponSpriteData{ItemName= "Wooden Blade", itemCategoryAndItemID = "(W)12", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,16,16,16)},
            new WeaponSpriteData{ItemName= "Insect Head", itemCategoryAndItemID = "(W)13", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,16,16,16)},
            new WeaponSpriteData{ItemName= "Neptune's Glaive", itemCategoryAndItemID = "(W)14", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,16,16,16)},
            new WeaponSpriteData{ItemName= "Forest Sword", itemCategoryAndItemID = "(W)15", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,16,16,16)},
            new WeaponSpriteData{ItemName= "Carving Knife", itemCategoryAndItemID = "(W)16", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,32,16,16)},
            new WeaponSpriteData{ItemName= "Iron Dirk", itemCategoryAndItemID = "(W)17", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,32,16,16)},
            new WeaponSpriteData{ItemName= "Burglar's Shank", itemCategoryAndItemID = "(W)18", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,32,16,16)},
            new WeaponSpriteData{ItemName= "Shadow Dagger", itemCategoryAndItemID = "(W)19", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,32,16,16)},
            new WeaponSpriteData{ItemName= "Elf Blade", itemCategoryAndItemID = "(W)20", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,32,16,16)},
            new WeaponSpriteData{ItemName= "Crystal Dagger", itemCategoryAndItemID = "(W)21", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,32,16,16)},
            new WeaponSpriteData{ItemName= "Wind Spire", itemCategoryAndItemID = "(W)22", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,32,16,16)},
            new WeaponSpriteData{ItemName= "Galaxy Dagger", itemCategoryAndItemID = "(W)23", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,32,16,16)},
            new WeaponSpriteData{ItemName= "Wood Club", itemCategoryAndItemID = "(W)24", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,48,16,16)},
            new WeaponSpriteData{ItemName= "Alex's Bat", itemCategoryAndItemID = "(W)25", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,48,16,16)},
            new WeaponSpriteData{ItemName= "Lead Rod", itemCategoryAndItemID = "(W)26", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,48,16,16)},
            new WeaponSpriteData{ItemName= "Wood Mallet", itemCategoryAndItemID = "(W)27", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,48,16,16)},
            new WeaponSpriteData{ItemName= "The Slammer", itemCategoryAndItemID = "(W)28", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,48,16,16)},
            new WeaponSpriteData{ItemName= "Galaxy Hammer", itemCategoryAndItemID = "(W)29", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,48,16,16)},
            new WeaponSpriteData{ItemName= "Sam's Old Guitar", itemCategoryAndItemID = "(W)30", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,48,16,16)},
            new WeaponSpriteData{ItemName= "Femur", itemCategoryAndItemID = "(W)31", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,48,16,16)},
            new WeaponSpriteData{ItemName= "Slingshot", itemCategoryAndItemID = "(W)32", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,64,16,16)},
            new WeaponSpriteData{ItemName= "Master Slingshot", itemCategoryAndItemID = "(W)33", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,64,16,16)},
            new WeaponSpriteData{ItemName= "Galaxy Slingshot", itemCategoryAndItemID = "(W)34", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,64,16,16)},
            new WeaponSpriteData{ItemName= "Elliott's Pencil", itemCategoryAndItemID = "(W)35", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,64,16,16)},
            new WeaponSpriteData{ItemName= "Maru's Wrench", itemCategoryAndItemID = "(W)36", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,64,16,16)},
            new WeaponSpriteData{ItemName= "Harvey's Mallet", itemCategoryAndItemID = "(W)37", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,64,16,16)},
            new WeaponSpriteData{ItemName= "Penny's Fryer", itemCategoryAndItemID = "(W)38", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,64,16,16)},
            new WeaponSpriteData{ItemName= "Leah's Whittler", itemCategoryAndItemID = "(W)39", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,64,16,16)},
            new WeaponSpriteData{ItemName= "Abby's Planchette", itemCategoryAndItemID = "(W)40", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,80,16,16)},
            new WeaponSpriteData{ItemName= "Seb's Lost Mace", itemCategoryAndItemID = "(W)41", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,80,16,16)},
            new WeaponSpriteData{ItemName= "Haley's Iron", itemCategoryAndItemID = "(W)42", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,80,16,16)},
            new WeaponSpriteData{ItemName= "Pirate's Sword", itemCategoryAndItemID = "(W)43", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,80,16,16)},
            new WeaponSpriteData{ItemName= "Cutlass", itemCategoryAndItemID = "(W)44", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,80,16,16)},
            new WeaponSpriteData{ItemName= "Wicked Kris", itemCategoryAndItemID = "(W)45", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,80,16,16)},
            new WeaponSpriteData{ItemName= "Kudgel", itemCategoryAndItemID = "(W)46", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,80,16,16)},
            new WeaponSpriteData{ItemName= "Scythe", itemCategoryAndItemID = "(W)47", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,80,16,16)},
            new WeaponSpriteData{ItemName= "Yeti Tooth", itemCategoryAndItemID = "(W)48", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,96,16,16)},
            new WeaponSpriteData{ItemName= "Rapier", itemCategoryAndItemID = "(W)49", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,96,16,16)},
            new WeaponSpriteData{ItemName= "Steel Falchion", itemCategoryAndItemID = "(W)50", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,96,16,16)},
            new WeaponSpriteData{ItemName= "Broken Trident", itemCategoryAndItemID = "(W)51", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,96,16,16)},
            new WeaponSpriteData{ItemName= "Tempered Broadsword", itemCategoryAndItemID = "(W)52", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,96,16,16)},
            new WeaponSpriteData{ItemName= "Golden Scythe", itemCategoryAndItemID = "(W)53", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,96,16,16)},
            new WeaponSpriteData{ItemName= "Dwarf Sword", itemCategoryAndItemID = "(W)54", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,96,16,16)},
            new WeaponSpriteData{ItemName= "Dwarf Hammer", itemCategoryAndItemID = "(W)55", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,96,16,16)},
            new WeaponSpriteData{ItemName= "Dwarf Dagger", itemCategoryAndItemID = "(W)56", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,112,16,16)},
            new WeaponSpriteData{ItemName= "Dragontooth Cutlass", itemCategoryAndItemID = "(W)57", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,112,16,16)},
            new WeaponSpriteData{ItemName= "Dragontooth Club", itemCategoryAndItemID = "(W)58", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,112,16,16)},
            new WeaponSpriteData{ItemName= "Dragontooth Shiv", itemCategoryAndItemID = "(W)59", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,112,16,16)},
            new WeaponSpriteData{ItemName= "Ossified Blade", itemCategoryAndItemID = "(W)60", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,112,16,16)},
            new WeaponSpriteData{ItemName= "Iridium Needle", itemCategoryAndItemID = "(W)61", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,112,16,16)},
            new WeaponSpriteData{ItemName= "Infinity Blade", itemCategoryAndItemID = "(W)62", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,112,16,16)},
            new WeaponSpriteData{ItemName= "Infinity Gavel", itemCategoryAndItemID = "(W)63", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,112,16,16)},
            new WeaponSpriteData{ItemName= "Infinity Dagger", itemCategoryAndItemID = "(W)64", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,128,16,16)},
            new WeaponSpriteData{ItemName= "Meowmere", itemCategoryAndItemID = "(W)65", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,128,16,16)},
            new WeaponSpriteData{ItemName= "Iridium Scythe", itemCategoryAndItemID = "(W)66", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,128,16,16)},
            new WeaponSpriteData{ItemName= "Axe", itemCategoryAndItemID = "(T)Axe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,160,16,32)},
            new WeaponSpriteData{ItemName= "Copper Axe", itemCategoryAndItemID = "(T)CopperAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,160,16,32)},
            new WeaponSpriteData{ItemName= "Steel Axe", itemCategoryAndItemID = "(T)SteelAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,160,16,32)},
            new WeaponSpriteData{ItemName= "Gold Axe", itemCategoryAndItemID = "(T)GoldAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,192,16,32)},
            new WeaponSpriteData{ItemName= "Iridium Axe", itemCategoryAndItemID = "(T)IridiumAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,192,16,32)},
            new WeaponSpriteData{ItemName= "Pickaxe", itemCategoryAndItemID = "(T)Pickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,96,16,32)},
            new WeaponSpriteData{ItemName= "Copper Pickaxe", itemCategoryAndItemID = "(T)CopperPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,96,16,32)},
            new WeaponSpriteData{ItemName= "Steel Pickaxe", itemCategoryAndItemID = "(T)SteelPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,96,16,32)},
            new WeaponSpriteData{ItemName= "Gold Pickaxe", itemCategoryAndItemID = "(T)GoldPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,128,16,32)},
            new WeaponSpriteData{ItemName= "Iridium Pickaxe", itemCategoryAndItemID = "(T)IridiumPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,128,16,32)},

        };
    }

    public class WeaponSpriteData
    {
        public string ItemName { get; set; }
        public string itemCategoryAndItemID {get;set;}
        public string tilesheetName { get; set; }
        public Rectangle SourceRect { get; set; }
        
    }
  
    public class ModEntry : Mod
    {
        private bool startSpinAnimation = false;
        private int staminaDrainCounter = 0;
        private bool isSpinning = false;
        private int SpinTickCounter = 0;
        private int weaponSpinTickCounter = 0;
        private int pickaxeSpinTickCounter = 0;
        private int axeSpinTickCounter = 0;
        private int rotateTickCounter = 0;
        private int facingDirectionIndex = 0;
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<ModConfig>();
            helper.Events.Input.ButtonPressed += OnButtonPressed;
            helper.Events.Input.ButtonReleased += OnButtonReleased;
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {

            //Return if world hasn't been loaded
            if (!Context.IsWorldReady)
                return;

            // Return if any active menu is open
            if (Game1.activeClickableMenu != null)
                return;

            // Return if a dialogue is open or message box is showing
            if (Game1.dialogueUp || Game1.messagePause)
                return;

            // Return if a shop menu is open
            if (Game1.activeClickableMenu is StardewValley.Menus.ShopMenu)
                return;

            // Return if player is in end-of-day menu (e.g. level up screen or summary)
            if (Game1.currentLocation.currentEvent != null && Game1.currentLocation.currentEvent.isFestival)
                return;


            if (Game1.player.UsingTool || Game1.player.isInBed.Value || Game1.player.isEating)
                return;



            Tool tool = Game1.player.CurrentTool;

            if ((e.Button == Config.SpinHotkey|| e.Button == Config.SpinHotkeyController) && tool is not null &&
                (tool is Pickaxe || tool is Axe || (tool is MeleeWeapon weapon )))
            {
                isSpinning = true;
                weaponSpinTickCounter = 0;
                pickaxeSpinTickCounter = 0;
                pickaxeSpinTickCounter = 0;
                rotateTickCounter = 0;
                facingDirectionIndex = 0;

                Game1.player.UsingTool = false;
                Game1.player.completelyStopAnimatingOrDoingAction();
            }
        }

        private void OnButtonReleased(object sender, ButtonReleasedEventArgs e)
        {
            if (!Context.IsWorldReady) return;

            if ((e.Button == Config.SpinHotkey || e.Button == Config.SpinHotkeyController) && isSpinning)
            {
                StopSpinning();
            }
        }

        private void StopSpinning()
        {
            startSpinAnimation = false;
            isSpinning = false;
            Game1.player.FarmerSprite.CurrentFrame = Game1.player.FacingDirection * 12;
            Game1.player.completelyStopAnimatingOrDoingAction();
            Game1.player.UsingTool = false;
            Game1.player.CanMove = true;

            weaponSpinTickCounter = 0;
            pickaxeSpinTickCounter = 0;
            axeSpinTickCounter = 0;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {

            if (!Context.IsWorldReady || !isSpinning) return;


            //checks for stamina if not enough won't spin or run any additiona code
            staminaDrainCounter++;
            if (staminaDrainCounter >= 6)
            {
                staminaDrainCounter = 0;
                float staminaCost = Config.BaseStaminaDrain;

                if (Game1.player.Stamina < staminaCost)
                {
                    //Monitor.Log("Not enough stamina to continue spinning.", LogLevel.Debug);
                    StopSpinning();
                    return;
                }

            }

            



            if (Game1.player.CurrentTool is Pickaxe)
            {
                pickaxeSpinTickCounter++;
            }
            if (Game1.player.CurrentTool is Axe)
            {
                axeSpinTickCounter++;
            }
            if (Game1.player.CurrentTool is MeleeWeapon)
            {
                weaponSpinTickCounter++;
            }


            if ((pickaxeSpinTickCounter >= (60 / Config.numberOfPickaxeSpinHitsPerSecond)) && !Game1.player.isEating)
            {
                pickaxeSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                float playerMiningLevel = Game1.player.MiningLevel * Config.reduceStaminaDrainForPickaxePerLevel;
                Game1.player.Stamina -= Math.Max(Config.BaseStaminaDrain - playerMiningLevel, 0.1f);
                
            }
            if ((axeSpinTickCounter >= (60/ Config.numberOfAxeSpinHitsPerSecond)) && !Game1.player.isEating)
             {
                axeSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                float playerForgageLevel = Game1.player.MiningLevel * Config.reduceStaminaDrainForAxePerLevel;
                Game1.player.Stamina -= Math.Max(Config.BaseStaminaDrain - playerForgageLevel, 0.1f);
                //Console.WriteLine($"playerForgageLevel  *.1: {playerForgageLevel} ");

            }
            if ((weaponSpinTickCounter >= (60 / Config.numberOfWeaponSpinHitsPerSecond)) && !Game1.player.isEating)
             {
                weaponSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();

                //drains weapon stamina only if weapon is not a scythe
                if (!Game1.player.CurrentTool.isScythe())
                {
                    Game1.player.Stamina = startStamina;
                    float playerCombatLevel = Game1.player.MiningLevel * Config.reduceStaminaDrainForWeaponsPerLevel;
                    Game1.player.Stamina -= Math.Max(Config.BaseStaminaDrain - playerCombatLevel, 0.1f);
                    //Console.WriteLine($"playerCombatLevel  *.1: {playerCombatLevel} ");
                }


            }

            if (startSpinAnimation)
            {

                ForceSpinAnimation(Game1.player.FacingDirection);
                SpawnWindEffect();
            }

        }

        
        private void ForceSpinAnimation(int facing)
        {
            int[] frames = facing switch
            {
                0 => new[] { 64, 65, 66, 67 },
                1 => new[] { 72, 73, 74, 75 },
                2 => new[] { 80, 81, 82, 83 },
                3 => new[] { 88, 89, 90, 91 },
                _ => new[] { 80, 81, 82, 83 }
            };

            int current = (Game1.ticks) % frames.Length;

            // This prevents walking animations from overriding spin
            Game1.player.FarmerSprite.StopAnimation();
            Game1.player.FarmerSprite.setCurrentFrame(frames[current]);
        }

        private void ApplySpinEffect()
        {
            Tool tool = Game1.player.CurrentTool;
            if (tool == null) return;

            Vector2 center = Game1.player.Tile;
         
            switch (tool)
            {
                case MeleeWeapon weapon:
                   
                    Game1.playSound("clubswipe");
                    ApplyWeaponEffect(weapon, center, Config.weaponSpinRadius);
                    break;

                case Pickaxe pickaxe:
                    Game1.playSound("clubswipe");
                    ApplyToolEffect(pickaxe, center, Config.pickaxeSpinRadius);
                    break;

                case Axe axe:
                    Game1.playSound("clubswipe");
                    ApplyToolEffect(axe, center, Config.axeSpinRadius);
                    break;
            }
        }

        private void ApplyToolEffect(Tool tool, Vector2 center, int radius)
        {
            GameLocation location = Game1.currentLocation;
            int power = Game1.player.CurrentTool.GetToolData().UpgradeLevel;
            Game1.player.CurrentTool.swingTicker = Game1.random.Next(999999);  //needs to reset in order to hit resource clump 2nd time
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {

                    Vector2 tile = new(center.X + x, center.Y + y);
                    int pixelX = (int)tile.X * 64;
                    int pixelY = (int)tile.Y * 64;
                    Vector2 hitPosition = new(pixelX, pixelY);

                    Game1.player.lastClick = hitPosition;

                    Game1.player.UsingTool = true;

                    // Hit terrain debris (rocks, twigs, etc.)
                    tool.DoFunction(location, pixelX, pixelY, power, Game1.player);

                    // Hit large resource clumps (like boulders, stumps)
                    if (location.resourceClumps != null)
                    {
                        foreach (var clump in location.resourceClumps)
                        {
                            if (clump.getBoundingBox().Contains(pixelX + 32, pixelY + 32))
                            {

                                clump.performToolAction(tool, power, tile);

                                break;
                            }
                        }
                    }

                    Game1.player.UsingTool = false;
                }
            }
        }

        private void ApplyWeaponEffect(MeleeWeapon weapon, Vector2 center, int radius)
        {
            GameLocation location = Game1.currentLocation;
            Random random = new((int)Game1.uniqueIDForThisGame + (int)Game1.stats.DaysPlayed + Game1.timeOfDay);

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    Vector2 tile = new(center.X + x, center.Y + y);
                    Rectangle area = new((int)tile.X * 64, (int)tile.Y * 64, 64, 64);

                    foreach (var npc in location.characters.ToList())
                    {
                        if (npc is Monster monster && monster.GetBoundingBox().Intersects(area))
                        {
                            int min = (int)(weapon.minDamage.Value * Config.weaponSpinPercentDamage);
                            int max = (int)(weapon.maxDamage.Value * Config.weaponSpinPercentDamage);
                            int damage = random.Next(min, max + 1);

                            float critChance = weapon.critChance.Value;
                            float critMult = weapon.critMultiplier.Value;

                            bool isCrit = random.NextDouble() < critChance;
                            if (isCrit)
                            {
                                Game1.playSound("crit");
                            }

                            location.damageMonster(
                                areaOfEffect: monster.GetBoundingBox(),
                                minDamage: damage,
                                maxDamage: damage,
                                isBomb: false,
                                knockBackModifier: 1f,
                                addedPrecision: 0,
                                critChance: isCrit ? 1f : 0f,
                                critMultiplier: isCrit ? critMult : 1f,
                                triggerMonsterInvincibleTimer: false,
                                who: Game1.player,
                                isProjectile: false
                            );
                        }
                    }

                    if (location.terrainFeatures.TryGetValue(tile, out var feature))
                    {
                        if (feature is Grass)
                        {
                            
                            location.terrainFeatures.Remove(tile);
                            Game1.playSound("cut");
                            //Game1.createObjectDebris("0", (int)tile.X, (int)tile.Y, Game1.player.UniqueMultiplayerID);
                        }
                    }



                    if (location.objects.TryGetValue(tile, out var obj))
                    {
                        if (obj.IsWeeds())
                        {
                            obj.performRemoveAction();
                            location.objects.Remove(tile);
                            Game1.playSound("cut");
                            Game1.createObjectDebris("771", (int)tile.X, (int)tile.Y, Game1.player.UniqueMultiplayerID);
                        }

                    }
                }
            }
        }

        private void SpawnWindEffect()
        {
            Vector2 playerCenter = Game1.player.Position + new Vector2(Game1.player.Sprite.SpriteWidth / 2, -32f);
            int numSprites = Config.numberOfSpinningSprite;
            double rotationSpeed = -500;
            double baseRotation = Game1.ticks * rotationSpeed;

            Tool tool = Game1.player.CurrentTool;
            TemporaryAnimatedSprite[] weaponEffect = new TemporaryAnimatedSprite[Config.weaponSpinRadius];
            TemporaryAnimatedSprite[] axeEffect = new TemporaryAnimatedSprite[Config.axeSpinRadius];
            TemporaryAnimatedSprite[] pickaxeEffect = new TemporaryAnimatedSprite[Config.pickaxeSpinRadius];

            for (int i = 0; i < numSprites; i++)
            {
                double angle = baseRotation + (Math.PI * 2 * i / numSprites);
                float orbitRadius = 48.0f;  //48


                float offsetX = (float)Math.Cos(angle) * orbitRadius;
                float offsetY = (float)Math.Sin(angle) * orbitRadius;
                Vector2 orbitPos = playerCenter + new Vector2(offsetX, offsetY);

                if (tool is Pickaxe)
                {
                    string pickaxeID = Game1.player.CurrentItem.GetItemTypeId() + Game1.player.CurrentItem.ItemId;
                    WeaponSpriteData match = Config.weaponSpriteData
                        .FirstOrDefault(w => w.itemCategoryAndItemID == pickaxeID);

                    string tileSheet = "TileSheets\\tools";
                    Rectangle sourceRect = new Rectangle(32, 48, 16, 32);

                    if (match != null)
                    {
                        tileSheet = match.tilesheetName;
                        sourceRect = match.SourceRect;

                    }
                    //Console.WriteLine($"pickaxeID: {pickaxeID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
    

                    for (int j = 0; j < pickaxeEffect.Length; j++)
                    {
                        orbitRadius = 100 + (50 * j);
                        offsetX = (float)Math.Cos(angle) * orbitRadius;
                        offsetY = (float)Math.Sin(angle) * orbitRadius;
                        orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                        pickaxeEffect[j] = new TemporaryAnimatedSprite(
                            tileSheet,
                            sourceRect,
                            100f, 1, 1, orbitPos, flicker: false, flipped: false)
                        {
                            rotation = (float)angle,
                            alpha = 0.6f,
                            scale = 3.0f,
                            motion = Vector2.Zero,
                            layerDepth = 1f
                        };


                        if (pickaxeEffect[j] != null)
                        {
                            Game1.currentLocation.temporarySprites.Add(pickaxeEffect[j]);
                        }
                        //Console.WriteLine($"weaponID: {weaponID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
                    }

                }
                else if (tool is Axe)
                {
                    string axeID = Game1.player.CurrentItem.GetItemTypeId() + Game1.player.CurrentItem.ItemId;
                    WeaponSpriteData match = Config.weaponSpriteData
                        .FirstOrDefault(w => w.itemCategoryAndItemID == axeID);

                    string tileSheet = "TileSheets\\tools";
                    Rectangle sourceRect = new Rectangle(32, 80, 16, 32);

                    if (match != null)
                    {
                        tileSheet = match.tilesheetName;
                        sourceRect = match.SourceRect;

                    }
                    //Console.WriteLine($"axeID: {axeID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");

                    for (int j = 0; j < axeEffect.Length; j++)
                    {
                        orbitRadius = 100 + (50 * j);
                        offsetX = (float)Math.Cos(angle) * orbitRadius;
                        offsetY = (float)Math.Sin(angle) * orbitRadius;
                        orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                        axeEffect[j] = new TemporaryAnimatedSprite(
                            tileSheet,
                            sourceRect,
                            100f, 1, 1, orbitPos, flicker: false, flipped: false)
                        {
                            rotation = (float)angle,
                            alpha = 0.4f,
                            scale = 3.0f,
                            motion = Vector2.Zero,
                            layerDepth = 1f
                        };

                        if (axeEffect[j] != null)
                        {
                            Game1.currentLocation.temporarySprites.Add(axeEffect[j]);
                        }

                        //Console.WriteLine($"weaponID: {weaponID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
                    }




                }
                else if (tool is MeleeWeapon weapon)
                {

                    string weaponID = Game1.player.CurrentItem.GetItemTypeId() + Game1.player.CurrentItem.ItemId;
                    WeaponSpriteData match = Config.weaponSpriteData
                        .FirstOrDefault(w => w.itemCategoryAndItemID == weaponID);

                    string tileSheet = "TileSheets\\weapons";
                    Rectangle sourceRect = new Rectangle(0, 0, 16, 16);

                    if (match != null)
                    {
                        tileSheet = match.tilesheetName;
                        sourceRect = match.SourceRect;
                    }


                    for (int j = 0; j < weaponEffect.Length; j++)
                    {
                        orbitRadius = 100 + (50*j);
                        offsetX = (float)Math.Cos(angle) * orbitRadius;
                        offsetY = (float)Math.Sin(angle) * orbitRadius;
                        orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                        weaponEffect[j] = new TemporaryAnimatedSprite(
                        tileSheet,
                        sourceRect, // First sword sprite
                        100f, 1, 1, orbitPos, flicker: false, flipped: false)
                        {
                            rotation = (float)angle,
                            alpha = 0.4f,
                            scale = 3.0f,
                            motion = Vector2.Zero,
                            layerDepth = 1f
                        };

                        if (weaponEffect[j] != null)
                        {
                            Game1.currentLocation.temporarySprites.Add(weaponEffect[j]);
                        }
                            
                        //Console.WriteLine($"weaponID: {weaponID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
                    }



                }


            }
        }


        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {

            // Uses Generic Mod Config Menu API to build a config UI.
            var gmcm = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (gmcm == null)
                return;

            // Register the mod.
            gmcm.Register(ModManifest, () => Config = new ModConfig(), () => Helper.WriteConfig(Config));

            gmcm.AddParagraph(
                ModManifest,
                text: () => "When selecting a tool or weapon, rightclick {hotkey configurable} to spin, and leftclick{hotkey configurable} if spin gets stucks. You can set the base stamina drain. The stamina drain reduces by 0.1 cost per skill level. Example: level 10 combat will reduce stamina drain when using weapons/tools"
            );

            gmcm.AddParagraph(
                ModManifest,
                text: () => "------------------------Hotkeys Settings------------------------"
            );
            gmcm.AddKeybind(
                ModManifest,
                name: () => "Spin Hotkey",
                tooltip: () => "Hold a weapon or tool and press this hotkey to use the spinning skill",
                getValue: () => Config.SpinHotkey,
                setValue: value => Config.SpinHotkey = value
            );

            gmcm.AddKeybind(
                ModManifest,
                name: () => "Spin Hotkey Controller",
                tooltip: () => "Spin Hotkey for controller, holding this will spin with weapon or tool",
                getValue: () => Config.SpinHotkeyController,
                setValue: value => Config.SpinHotkeyController = value
            );

            gmcm.AddParagraph(
                ModManifest,
                text: () => "------------------------Weapon+Tool Settings------------------------"
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.BaseStaminaDrain,
                setValue: value => Config.BaseStaminaDrain = value,
                name: () => "Stamina Drain",
                tooltip: () => "Set how much stamina drains when spinning",
                min: 0.0f,
                max: 10.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfSpinningSprite,
                setValue: value => Config.numberOfSpinningSprite = value,
                name: () => "Number of Spinning Sprite",
                tooltip: () => "Lower for better performance, higher for better quality, default = 5",
                min: 3,
                max: 20,
                interval: 1
            );



            gmcm.AddParagraph(
                ModManifest,
                text: () => "------------------------Weapon Settings------------------------"
            );


            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForWeaponsPerLevel,
                setValue: value => Config.reduceStaminaDrainForWeaponsPerLevel = value,
                name: () => "Reduce Stamina Drain Per Level",
                tooltip: () => "Reduce Stamina Drain when using spinning weapons by this amount per Combat Skill level",
                min: 0.00f,
                max: 1.0f,
                interval: 0.01f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.weaponSpinRadius,
                setValue: value => Config.weaponSpinRadius = value,
                name: () => "Weapon Max Spin Radius",
                tooltip: () => "Set Weapon Max Spin Radius",
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.weaponSpinPercentDamage,
                setValue: value => Config.weaponSpinPercentDamage = value,
                name: () => "Weapon Spin Percent Damage",
                tooltip: () => "Set to apply a percent of the weapon's base damage. Example if set to .50 only deals 50% of weapon damage per spin",
                min: 0.01f,
                max: 1.0f,
                interval: 0.01f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfWeaponSpinHitsPerSecond,
                setValue: value => Config.numberOfWeaponSpinHitsPerSecond = value,
                name: () => "Weapon Spin Hit Per Sec",
                tooltip: () => "Number of times Spin attack hits monster per second",
                min: 1,
                max: 60,
                interval: 1
            );


            gmcm.AddParagraph(
                ModManifest,
                text: () => "------------------------Pickaxe Settings------------------------"
            );




            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForPickaxePerLevel,
                setValue: value => Config.reduceStaminaDrainForPickaxePerLevel = value,
                name: () => "Reduce Stamina Drain Per Level",
                tooltip: () => "Reduce Stamina Drain when using spinning pickaxe by this amount per minning Skill level",
                min: 0.00f,
                max: 1.0f,
                interval: 0.01f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.pickaxeSpinRadius,
                setValue: value => Config.pickaxeSpinRadius = value,
                name: () => "Pickaxe Max Spin Radius",
                tooltip: () => "Set Pickaxe Max Spin Radius",
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfPickaxeSpinHitsPerSecond,
                setValue: value => Config.numberOfPickaxeSpinHitsPerSecond = value,
                name: () => "Pickaxe Spin Hit Per Sec",
                tooltip: () => "Number of times pickaxe spin attack hits area per second",
                min: 1,
                max: 60,
                interval: 1
            );


            gmcm.AddParagraph(
                ModManifest,
                text: () => "------------------------Axe Settings------------------------"
            );


            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForAxePerLevel,
                setValue: value => Config.reduceStaminaDrainForAxePerLevel = value,
                name: () => "Reduce Stamina Drain Per Level",
                tooltip: () => "Reduce Stamina Drain when using spinning axe by this amount per Foraging Skill level",
                min: 0.00f,
                max: 1.0f,
                interval: 0.01f
            );
            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.axeSpinRadius,
                setValue: value => Config.axeSpinRadius = value,
                name: () => "Set Axe Max Spin Radius",
                tooltip: () => "Set Axe Max Spin Radius",
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfAxeSpinHitsPerSecond,
                setValue: value => Config.numberOfAxeSpinHitsPerSecond = value,
                name: () => "Axe Spin Hit Per Sec",
                tooltip: () => "Number of times axe spin attack hits area per second",
                min: 1,
                max: 60,
                interval: 1
            );






        }


    }


}


