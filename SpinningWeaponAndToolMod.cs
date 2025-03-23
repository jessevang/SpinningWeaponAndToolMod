// All using directives stay the same
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Tools;
using Microsoft.Xna.Framework;
using StardewValley.Monsters;
using StardewValley.TerrainFeatures;
using GenericModConfigMenu;


namespace SpinningWeaponAndToolMod
{
    public class ModConfig
    {
        public SButton SpinHotkey { get; set; } = SButton.MouseRight;
        public SButton UnstuckAnimation { get; set; } = SButton.MouseLeft;
        public float BaseStaminaDrain { get; set; } = 2.0f;
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
        private int spinTickCounter = 0;
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
            if (!Context.IsWorldReady) return;

            if (isSpinning && (e.Button == Config.UnstuckAnimation || e.Button.IsUseToolButton()))
            {
                StopSpinning();
                Game1.player.UsingTool = false;
                Game1.player.completelyStopAnimatingOrDoingAction();
                Game1.player.CanMove = true;
                return;
            }

            Tool tool = Game1.player.CurrentTool;

            if (e.Button == Config.SpinHotkey && tool is not null &&
                (tool is Pickaxe || tool is Axe || (tool is MeleeWeapon weapon )))
            {
                isSpinning = true;
                spinTickCounter = 0;
                rotateTickCounter = 0;
                facingDirectionIndex = 0;

                Game1.player.UsingTool = false;
                Game1.player.completelyStopAnimatingOrDoingAction();
            }
        }

        private void OnButtonReleased(object sender, ButtonReleasedEventArgs e)
        {
            if (!Context.IsWorldReady) return;

            if (e.Button == Config.SpinHotkey && isSpinning)
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
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {

            if (!Context.IsWorldReady || !isSpinning) return;

            staminaDrainCounter++;
            if (staminaDrainCounter >= 6)
            {
                staminaDrainCounter = 0;
                float staminaCost = Config.BaseStaminaDrain;

                if (Game1.player.Stamina < staminaCost)
                {
                    Monitor.Log("Not enough stamina to continue spinning.", LogLevel.Debug);
                    StopSpinning();
                    return;
                }



            }

            rotateTickCounter++;
            if (rotateTickCounter >= 10)
            {
                rotateTickCounter = 0;
                Game1.player.faceDirection(facingDirectionIndex);
                facingDirectionIndex = (facingDirectionIndex + 1) % 4;
            }



            spinTickCounter++;
            if (spinTickCounter >= 10)
            {
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                spinTickCounter = 0;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                if (Game1.player.CurrentTool is Pickaxe)
                {
                    float playerMiningLevel = Game1.player.MiningLevel * 0.1f;
                    Game1.player.Stamina -= Math.Max(Config.BaseStaminaDrain - playerMiningLevel, 0.1f);
                    Console.WriteLine( $"Mining level *.1: { playerMiningLevel} ");
                }
                else if ( Game1.player.CurrentTool is Axe)
                {
                    float playerForgageLevel = Game1.player.ForagingLevel * 0.1f;
                    Game1.player.Stamina -= Math.Max(Config.BaseStaminaDrain - playerForgageLevel, 0.1f);
                    Console.WriteLine($"playerForgageLevel  *.1: {playerForgageLevel} ");
                }
                else if (Game1.player.CurrentItem is MeleeWeapon weapon && !weapon.isScythe())
                {
                    float playerCombatLevel = Game1.player.CombatLevel * 0.1f;
                    Game1.player.Stamina -= Math.Max(Config.BaseStaminaDrain - playerCombatLevel, 0.1f);
                    Console.WriteLine($"playerCombatLevel  *.1: {playerCombatLevel} ");
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
            int radius = 5;
         
            switch (tool)
            {
                case MeleeWeapon weapon:
                   
                    Game1.playSound("clubswipe");
                    ApplyWeaponEffect(weapon, center, radius);
                    break;

                case Pickaxe pickaxe:
                    Game1.playSound("clubswipe");
                    ApplyToolEffect(pickaxe, center, radius);
                    break;

                case Axe axe:
                    Game1.playSound("clubswipe");
                    ApplyToolEffect(axe, center, radius);
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
                            int min = weapon.minDamage.Value;
                            int max = weapon.maxDamage.Value;
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


            // Perfectly center the effect on the farmer's chest
            Vector2 playerCenter = Game1.player.Position + new Vector2(Game1.player.Sprite.SpriteWidth / 2, -32f);

            float windScale = 5.0f;
            int numSprites = 5;
            double rotationSpeed = -500;
            double baseRotation = Game1.ticks * rotationSpeed;
            float windradius = 0f;
            Tool tool = Game1.player.CurrentTool;

            for (int i = 0; i < numSprites; i++)
            {
                double angle = baseRotation + (Math.PI * 2 * i / numSprites);
                float orbitRadius = 48.0f;  //48

                // Adjust orbit radius based on tool
                if (tool is Axe or Pickaxe)
                    orbitRadius = 300;   //64
                else if (tool is MeleeWeapon weapon)
                    orbitRadius = 300;  //48

                float offsetX = (float)Math.Cos(angle) * orbitRadius;
                float offsetY = (float)Math.Sin(angle) * orbitRadius;
                Vector2 orbitPos = playerCenter + new Vector2(offsetX, offsetY);

                // Tool sprite
                TemporaryAnimatedSprite effect1 = null;
                TemporaryAnimatedSprite effect2 = null;
                TemporaryAnimatedSprite effect3 = null;
                TemporaryAnimatedSprite effect4 = null;
                TemporaryAnimatedSprite effect5 = null;

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
                    int pickaxeIndex = 62; // (col 2, row 5)
                    effect1 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 250;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect2 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 200;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect3 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 150;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect4 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 100;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect5 = new TemporaryAnimatedSprite(
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

                    if (effect1 != null && effect2 != null && effect3 != null && effect4 != null && effect5 != null)
                    {
                        Game1.currentLocation.temporarySprites.Add(effect1);
                        Game1.currentLocation.temporarySprites.Add(effect2);
                        Game1.currentLocation.temporarySprites.Add(effect3);
                        Game1.currentLocation.temporarySprites.Add(effect4);
                        Game1.currentLocation.temporarySprites.Add(effect5);
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
                    int axeIndex = 74; // (col 2, row 6)
                    effect1 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 250;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect2 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 200;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect3 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 150;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect4 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 100;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect5 = new TemporaryAnimatedSprite(
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

                    if (effect1 != null && effect2 != null && effect3 != null && effect4 != null && effect5 != null)
                    {
                        Game1.currentLocation.temporarySprites.Add(effect1);
                        Game1.currentLocation.temporarySprites.Add(effect2);
                        Game1.currentLocation.temporarySprites.Add(effect3);
                        Game1.currentLocation.temporarySprites.Add(effect4);
                        Game1.currentLocation.temporarySprites.Add(effect5);
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
                    //Console.WriteLine($"weaponID: {weaponID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
                    effect1 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 250;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect2 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 200;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect3 = new TemporaryAnimatedSprite(
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

                    orbitRadius = 150;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect4 = new TemporaryAnimatedSprite(
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
                    orbitRadius = 100;
                    offsetX = (float)Math.Cos(angle) * orbitRadius;
                    offsetY = (float)Math.Sin(angle) * orbitRadius;
                    orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                    effect5 = new TemporaryAnimatedSprite(
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


                    if (effect1 != null && effect2 != null && effect3 != null && effect4 != null && effect5 != null)
                    {
                        Game1.currentLocation.temporarySprites.Add(effect1);
                        Game1.currentLocation.temporarySprites.Add(effect2);
                        Game1.currentLocation.temporarySprites.Add(effect3);
                        Game1.currentLocation.temporarySprites.Add(effect4);
                        Game1.currentLocation.temporarySprites.Add(effect5);
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
                text: () => "When selecting a tool or weapon, rightclick {hotkey configurable} to spin, and leftclick{hotkey configurable} if spin gets stucks. You can set the base stamina drain. The stamina drain reduces by 0.1 cost per skill level. Example: level 10 combat will reduce stamina drain when using weapons by 1.0 "
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


            gmcm.AddKeybind(
                ModManifest,
                name: () => "Spin Hotkey",
                tooltip: () => "Hold a weapon or tool and press this hotkey to use the spinning skill",
                getValue: () => Config.SpinHotkey,
                setValue: value => Config.SpinHotkey = value
            );

            gmcm.AddKeybind(
                ModManifest,
                name: () => "Unstuck frozen animation",
                tooltip: () => "Sometimes when spinning and then performming other animations, character could sometimes get stuck, this hotkey will unstuck the animation",
                getValue: () => Config.UnstuckAnimation,
                setValue: value => Config.UnstuckAnimation = value
            );
      



        }


    }


}


