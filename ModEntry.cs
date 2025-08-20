// All using directives stay the same
using GenericModConfigMenu;
using HarmonyLib;
using LeFauxMods.Common.Integrations.IconicFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Monsters;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;



namespace SpinningWeaponAndToolMod
{
    public class ModConfig
    {
        //Mode
        public string Mode { get; set; } = "UnifiedExperience";
        public string AbilityUses { get; set; } = "Energy";

        //hotkeys
        public KeybindList SpinHotkey { get; set; } = new(
            new Keybind(SButton.MouseRight),
            new Keybind(SButton.ControllerA)
        );

        public KeybindList OpenSkinMenu { get; set; } = new(
            new Keybind(SButton.F8),
            new Keybind(SButton.RightShoulder, SButton.LeftStick)
        );

        //all tool and weapons
        public float BaseStaminaDrain { get; set; } = .0f;
        public float reduceStaminaDrainForWeaponsPerLevel { get; set; } = 0.0f;
        public int numberOfSpinningSprite { get; set; } = 5;

        //weapons
        public int weaponSpinRadius { get; set; } = 1;
        public int swordSpinRadius { get; set; } = 1;
        public int daggerSpinRadius { get; set; } = 1;
        public int hammerSpinRadius {  get; set; } = 1;
        public float weaponSpinRadiusPerCombatLevel { get; set; } = 0.0f;
        public float allWeaponSpinPercentDamage { get; set; } = 1.0f;
        public int numberOfWeaponSpinHitsPerSecond { get; set; } = 3;
        public int numberOfSwordSpinHitsPerSecond { get; set; } = 4;
        public int numberOfDaggerSpinHitsPerSecond { get; set; } = 5;
        public int numberOfHammerSpinHitsPerSecond { get; set; } = 3;
        
        //axe
        public int axeSpinRadius { get; set; } = 1;
        public float axeSpinRadiusIncreaseByEachToolUpgradeLevel { get; set; } = 0.0f;
        public int numberOfAxeSpinHitsPerSecond { get; set; } = 3;
        public float axeEnchantEfficient { get; set; } = 0f;
        public int axeEnchantSwift { get; set; } = 0;
        public float reduceStaminaDrainForAxePerLevel { get; set; } = 0.0f;

        //pickaxe
        public int pickaxeSpinRadius { get; set; } = 1;
        public int pickaxeEnchantSwift { get; set; } = 0; 
        public float pickaxeEnchantEfficient { get; set; } = 0f; 
        public float pickaxeSpinRadiusIncreaseByEachToolUpgradeLevel { get; set; } = 0.0f;
        public int numberOfPickaxeSpinHitsPerSecond { get; set; } = 3;
        public float reduceStaminaDrainForPickaxePerLevel { get; set; } = 0.0f;


        //watering can
        public float reduceStaminaDrainForWateringCanPerLevel { get; set; } = 0.0f;
        public float wateringcanSpinRadiusIncreaseByEachToolUpgradeLevel { get; set; } = 0.0f;
        public int wateringcanRadius { get; set; } = 1;
        public float wateringcanEnchantEfficient { get; set; } = 0f;
        public float wateringcanEnchantReaching { get; set; } = 0f;


        //Hoe
        public float reduceStaminaDrainForHoePerLevel { get; set; } = 0.0f;
        public int numberOfHoeSpinHitsPerSecond { get; set; } = 3;
        public float HoeSpinRadiusIncreaseByEachToolUpgradeLevel { get; set; } = 0.0f;
        public int HoeRadius { get; set; } = 1;
        public float HoeEnchantSwift{ get; set; } = 0.0f;
        public float HoeEnchantEfficient { get; set; } = 0.0f;
        public float HoeEnchantReaching { get; set; } = 0.0f;




        public string note { get; set; } = "Feel free add your weapon sprite or update existing one if you want custom mod sprites for weapons or tools to appear when using/tools the spin attack";
        public List<WeaponSpriteData> weaponSpriteData { get; set; } = new List<WeaponSpriteData>
        {

            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Rusty Sword", itemCategoryAndItemID = "(W)0", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Silver Saber", itemCategoryAndItemID = "(W)1", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dark Sword", itemCategoryAndItemID = "(W)2", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Holy Blade", itemCategoryAndItemID = "(W)3", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Galaxy Sword", itemCategoryAndItemID = "(W)4", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Bone Sword", itemCategoryAndItemID = "(W)5", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iron Edge", itemCategoryAndItemID = "(W)6", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Templar's Blade", itemCategoryAndItemID = "(W)7", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,0,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Obsidian Edge", itemCategoryAndItemID = "(W)8", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Lava Katana", itemCategoryAndItemID = "(W)9", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Claymore", itemCategoryAndItemID = "(W)10", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Smallsword", itemCategoryAndItemID = "(W)11", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Wooden Blade", itemCategoryAndItemID = "(W)12", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Insect Head", itemCategoryAndItemID = "(W)13", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Neptune's Glaive", itemCategoryAndItemID = "(W)14", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Forest Sword", itemCategoryAndItemID = "(W)15", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,16,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Carving Knife", itemCategoryAndItemID = "(W)16", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iron Dirk", itemCategoryAndItemID = "(W)17", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Burglar's Shank", itemCategoryAndItemID = "(W)18", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Shadow Dagger", itemCategoryAndItemID = "(W)19", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Elf Blade", itemCategoryAndItemID = "(W)20", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Crystal Dagger", itemCategoryAndItemID = "(W)21", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Wind Spire", itemCategoryAndItemID = "(W)22", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Galaxy Dagger", itemCategoryAndItemID = "(W)23", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,32,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Wood Club", itemCategoryAndItemID = "(W)24", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Alex's Bat", itemCategoryAndItemID = "(W)25", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Lead Rod", itemCategoryAndItemID = "(W)26", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Wood Mallet", itemCategoryAndItemID = "(W)27", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "The Slammer", itemCategoryAndItemID = "(W)28", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Galaxy Hammer", itemCategoryAndItemID = "(W)29", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Sam's Old Guitar", itemCategoryAndItemID = "(W)30", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Femur", itemCategoryAndItemID = "(W)31", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,48,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Slingshot", itemCategoryAndItemID = "(W)32", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Master Slingshot", itemCategoryAndItemID = "(W)33", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Galaxy Slingshot", itemCategoryAndItemID = "(W)34", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Elliott's Pencil", itemCategoryAndItemID = "(W)35", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Maru's Wrench", itemCategoryAndItemID = "(W)36", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Harvey's Mallet", itemCategoryAndItemID = "(W)37", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Penny's Fryer", itemCategoryAndItemID = "(W)38", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Leah's Whittler", itemCategoryAndItemID = "(W)39", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,64,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Abby's Planchette", itemCategoryAndItemID = "(W)40", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Seb's Lost Mace", itemCategoryAndItemID = "(W)41", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Haley's Iron", itemCategoryAndItemID = "(W)42", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Pirate's Sword", itemCategoryAndItemID = "(W)43", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Cutlass", itemCategoryAndItemID = "(W)44", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Wicked Kris", itemCategoryAndItemID = "(W)45", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Kudgel", itemCategoryAndItemID = "(W)46", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Scythe", itemCategoryAndItemID = "(W)47", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,80,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Yeti Tooth", itemCategoryAndItemID = "(W)48", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Rapier", itemCategoryAndItemID = "(W)49", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Falchion", itemCategoryAndItemID = "(W)50", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Broken Trident", itemCategoryAndItemID = "(W)51", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Tempered Broadsword", itemCategoryAndItemID = "(W)52", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Golden Scythe", itemCategoryAndItemID = "(W)53", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dwarf Sword", itemCategoryAndItemID = "(W)54", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dwarf Hammer", itemCategoryAndItemID = "(W)55", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,96,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dwarf Dagger", itemCategoryAndItemID = "(W)56", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dragontooth Cutlass", itemCategoryAndItemID = "(W)57", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dragontooth Club", itemCategoryAndItemID = "(W)58", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Dragontooth Shiv", itemCategoryAndItemID = "(W)59", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(48,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Ossified Blade", itemCategoryAndItemID = "(W)60", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(64,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Needle", itemCategoryAndItemID = "(W)61", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(80,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Infinity Blade", itemCategoryAndItemID = "(W)62", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(96,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Infinity Gavel", itemCategoryAndItemID = "(W)63", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(112,112,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Infinity Dagger", itemCategoryAndItemID = "(W)64", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0,128,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Meowmere", itemCategoryAndItemID = "(W)65", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(16,128,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Scythe", itemCategoryAndItemID = "(W)66", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(32,128,16,16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Axe", itemCategoryAndItemID = "(T)Axe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,160,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Copper Axe", itemCategoryAndItemID = "(T)CopperAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,160,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Axe", itemCategoryAndItemID = "(T)SteelAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,160,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Gold Axe", itemCategoryAndItemID = "(T)GoldAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,192,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Axe", itemCategoryAndItemID = "(T)IridiumAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,192,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Pickaxe", itemCategoryAndItemID = "(T)Pickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,96,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Copper Pickaxe", itemCategoryAndItemID = "(T)CopperPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,96,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Pickaxe", itemCategoryAndItemID = "(T)SteelPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,96,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Gold Pickaxe", itemCategoryAndItemID = "(T)GoldPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,128,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Pickaxe", itemCategoryAndItemID = "(T)IridiumPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,128,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Rusty Sword", itemCategoryAndItemID = "(W)0", tilesheetName = "TileSheets\\weapons", SourceRect = new Rectangle(0, 0, 16, 16)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Axe", itemCategoryAndItemID = "(T)Axe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,160,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Copper Axe", itemCategoryAndItemID = "(T)CopperAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,160,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Axe", itemCategoryAndItemID = "(T)SteelAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,160,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Gold Axe", itemCategoryAndItemID = "(T)GoldAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,192,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Axe", itemCategoryAndItemID = "(T)IridiumAxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,192,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Pickaxe", itemCategoryAndItemID = "(T)Pickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,96,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Copper Pickaxe", itemCategoryAndItemID = "(T)CopperPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,96,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Pickaxe", itemCategoryAndItemID = "(T)SteelPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,96,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Gold Pickaxe", itemCategoryAndItemID = "(T)GoldPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,128,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Pickaxe", itemCategoryAndItemID = "(T)IridiumPickaxe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,128,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Watering Can", itemCategoryAndItemID = "(T)WateringCan", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(48,224,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Copper Watering Can", itemCategoryAndItemID = "(T)CopperWateringCan", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(160,224,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Watering Can", itemCategoryAndItemID = "(T)SteelWateringCan", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(272,224,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Gold Watering Can", itemCategoryAndItemID = "(T)GoldWateringCan", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(48,256,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Watering Can", itemCategoryAndItemID = "(T)IridiumWateringCan", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(160,256,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Hoe", itemCategoryAndItemID = "(T)Hoe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,32,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Copper Hoe", itemCategoryAndItemID = "(T)CopperHoe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,32,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Steel Hoe", itemCategoryAndItemID = "(T)SteelHoe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(304,32,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Gold Hoe", itemCategoryAndItemID = "(T)GoldHoe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(80,64,16,32)},
            new WeaponSpriteData{ModID = null, fullPath = null, ItemName= "Iridium Hoe", itemCategoryAndItemID = "(T)IridiumHoe", tilesheetName = "TileSheets\\tools", SourceRect = new Rectangle(192,64,16,32)}

        };
    }

    public class WeaponSpriteData
    {
        public string ModID { get; set; }
        public string fullPath { get; set; }
        public string ItemName { get; set; }
        public string itemCategoryAndItemID {get;set;}
        public string tilesheetName { get; set; }
        public Rectangle SourceRect { get; set; }

        
    }
  
     
    public partial class ModEntry : Mod
    {
        private List<string> modIds = new(); // Initialize to avoid null error
        private ITranslationHelper i18n;
        public static ModEntry Instance { get; private set; }
        private bool startSpinAnimation = false;
        private int staminaDrainCounter = 0;
        private bool isSpinning = false;
        private int SpinTickCounter = 0;
        private int weaponSpinTickCounter = 0;
        private int pickaxeSpinTickCounter = 0;
        private int axeSpinTickCounter = 0;
        private int wateringcanSpinTickCounter = 0;
        private int hoeSpinTickCounter = 0;
        private int rotateTickCounter = 0;
        private int facingDirectionIndex = 0;
        private ModConfig Config;
        private string lastItemKey = null;


        //API Levels
        private int SpinningWeaponLevel;
        private int SpinningAxeLevel;
        private int SpinningPickAxeLevel;
        private int SpinningWateringCanLevel;
        private int SpinningHoeLevel;
        private UnifiedExperienceSystem.IUnifiedExperienceAPI? uesApi;

        //Ability Level Up settings
        private float AbilityReduceStaminaDrainBy { get; set; } = 0;
        private float AbilityIncreaseSpinRadiusBy{ get; set; } = 0;

        //Used with Iconic Framework for spinning
        private int IconicFrameworkButtonPressCount = 0;
        private Tool spinningTool;


        public override void Entry(IModHelper helper)
        {

            this.i18n = helper.Translation;
            Instance = this;
            Config = helper.ReadConfig<ModConfig>();
            var harmony = new Harmony(ModManifest.UniqueID);
            harmony.PatchAll(); // Automatically applies all [HarmonyPatch] classes in your mod
            helper.Events.Input.ButtonPressed += OnButtonPressed;
            helper.Events.Input.ButtonReleased += OnButtonReleased;
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

       
        private void StopSpinning()
        {
            spinningTool = null;
            IconicFrameworkButtonPressCount = 0;
            startSpinAnimation = false;
            isSpinning = false;
            Game1.player.FarmerSprite.CurrentFrame = Game1.player.FacingDirection * 12;
            Game1.player.completelyStopAnimatingOrDoingAction();
            Game1.player.UsingTool = false;
            Game1.player.CanMove = true;

            weaponSpinTickCounter = 0;
            pickaxeSpinTickCounter = 0;
            axeSpinTickCounter = 0;
            wateringcanSpinTickCounter = 0;
            hoeSpinTickCounter = 0;
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

        private void ApplySpinAnimation()
        {
            Tool tool = Game1.player.CurrentTool;
            if (tool == null) return;

            Vector2 center = Game1.player.Tile;

            switch (tool)
            {
                case MeleeWeapon weapon:

                    switch (weapon.type.Value)
                    {
                        case 3: // Sword
                            //Console.WriteLine($"Weapon is : {weapon.type.Value}");
                            SpawnWeaponEffect((int)AbilityIncreaseSpinRadiusBy+ Config.swordSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;

                        case 1: // Dagger
                            //Console.WriteLine($"Weapon is : {weapon.type.Value}");
                            SpawnWeaponEffect((int)AbilityIncreaseSpinRadiusBy + Config.daggerSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;

                        case 2: // Club / Hammer
                            //Console.WriteLine($"Weapon is : {weapon.type.Value}");
                            SpawnWeaponEffect((int)AbilityIncreaseSpinRadiusBy + Config.hammerSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;

                        default:
                            //Console.WriteLine($"Weapon is : {weapon.type.Value}");
                            SpawnWeaponEffect((int)AbilityIncreaseSpinRadiusBy + Config.weaponSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;
                    }
                    break;

                case Pickaxe pickaxe:

                    SpawnToolEffect(pickaxe, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.pickaxeSpinRadius + Game1.player.CurrentTool.UpgradeLevel * Config.pickaxeSpinRadiusIncreaseByEachToolUpgradeLevel));
                   
                    break;

                case Axe axe:

                    SpawnToolEffect(axe, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.axeSpinRadius + Game1.player.CurrentTool.UpgradeLevel * Config.axeSpinRadiusIncreaseByEachToolUpgradeLevel));
                  
                    break;

                case WateringCan wateringcan:

                    SpawnToolEffect(wateringcan, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.wateringcanRadius + Game1.player.CurrentTool.UpgradeLevel * Config.wateringcanSpinRadiusIncreaseByEachToolUpgradeLevel));

                    break;
                
                case Hoe hoe:

                    SpawnToolEffect(hoe, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.HoeRadius + Game1.player.CurrentTool.UpgradeLevel * Config.HoeSpinRadiusIncreaseByEachToolUpgradeLevel));

                    break;
            }
        }

        private void ApplySpinEffect()
        {
            Tool tool = Game1.player.CurrentTool;
            if (tool == null) return;

            Vector2 center = Game1.player.Tile;
         
            switch (tool)
            {
                case MeleeWeapon weapon:

                    switch (weapon.type.Value)
                    {
                        case 3: // Sword
                            Game1.playSound("swordswipe");
                           
                            ApplyWeaponEffect(weapon, center, (int)AbilityIncreaseSpinRadiusBy + Config.swordSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;

                        case 1: // Dagger
                            Game1.playSound("daggerswipe");
                           
                            ApplyWeaponEffect(weapon, center, (int)AbilityIncreaseSpinRadiusBy + Config.daggerSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;

                        case 2: // Club / Hammer
                            Game1.playSound("clubswipe");
                           
                            ApplyWeaponEffect(weapon, center, (int)AbilityIncreaseSpinRadiusBy + Config.hammerSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            break;

                        default:
                            Game1.playSound("swordswipe");  //mainly for Scythe
                          
                            ApplyWeaponEffect(weapon, center, (int)AbilityIncreaseSpinRadiusBy + Config.weaponSpinRadius + (int)(Game1.player.CombatLevel * Config.weaponSpinRadiusPerCombatLevel));
                            
                            
                            break;
                    }
                    break;

                case Pickaxe pickaxe:
                    Game1.playSound("clubswipe");
                   
                    ApplyToolEffect(pickaxe, center, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.pickaxeSpinRadius + Game1.player.CurrentTool.UpgradeLevel * Config.pickaxeSpinRadiusIncreaseByEachToolUpgradeLevel));
                    break;

                case Axe axe:
                    Game1.playSound("clubswipe");
                   
                    ApplyToolEffect(axe, center, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.axeSpinRadius + (Game1.player.CurrentTool.UpgradeLevel * Config.axeSpinRadiusIncreaseByEachToolUpgradeLevel)));
                    break;

                case WateringCan wateringcan:
                    Game1.playSound("wateringCan");

                    ApplyToolEffect(wateringcan, center, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.wateringcanRadius + (Game1.player.CurrentTool.UpgradeLevel * Config.wateringcanSpinRadiusIncreaseByEachToolUpgradeLevel)));
                    break;

                case Hoe hoe:
                    Game1.playSound("hoeHit");

                    ApplyToolEffect(hoe, center, (int)AbilityIncreaseSpinRadiusBy + (int)(Config.HoeRadius + (Game1.player.CurrentTool.UpgradeLevel * Config.HoeSpinRadiusIncreaseByEachToolUpgradeLevel)));
                    break;
            }
        }

        private void ApplyToolEffect(Tool tool, Vector2 center, int radius)
        {
            GameLocation location = Game1.currentLocation;
            int power = Game1.player.CurrentTool.GetToolData().UpgradeLevel;
            Game1.player.CurrentTool.swingTicker = Game1.random.Next(999999); // needed for resource clumps

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    Vector2 tile = new(center.X + x, center.Y + y);
                    int pixelX = (int)tile.X * Game1.tileSize;
                    int pixelY = (int)tile.Y * Game1.tileSize;

                    Game1.player.lastClick = tile; // set to tile, not pixel position
                   
                    Game1.player.UsingTool = true;


                    if (tool is WateringCan wateringCan)
                    {
                        wateringCan.upgradeLevel.Set(0);
                        tool.DoFunction(location, pixelX, pixelY, 0, Game1.player);
                        wateringCan.upgradeLevel.Set(power);
                    }
                    if (tool is Hoe hoe)
                    {
                        hoe.upgradeLevel.Set(0);
                        tool.DoFunction(location, pixelX, pixelY, 0, Game1.player);
                        hoe.upgradeLevel.Set(power);
                    }
                    else if (tool is Axe || tool is Pickaxe)
                    {
                        tool.DoFunction(location, pixelX, pixelY, power, Game1.player);

                        // Resource clumps
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
                    }

                    Game1.player.UsingTool = false;
                }
            }
        }

        private void ApplyWeaponEffect(MeleeWeapon weapon, Vector2 center, int radius)
        {
            GameLocation location = Game1.currentLocation;
            Random random = new((int)Game1.uniqueIDForThisGame + (int)Game1.stats.DaysPlayed + Game1.timeOfDay);
            Farmer player = Game1.player;

            // Determine the type of scythe
            bool isRegularScythe = weapon.Name == "Scythe";
            bool isGoldenScythe = weapon.Name == "Golden Scythe";
            bool isIridiumScythe = weapon.Name == "Iridium Scythe";

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    Vector2 tile = new(center.X + x, center.Y + y);
                    Rectangle area = new((int)tile.X * 64, (int)tile.Y * 64, 64, 64);

                    // Damage monsters within the area
                    foreach (var npc in location.characters.ToList())
                    {
                        if (npc is Monster monster && monster.GetBoundingBox().Intersects(area))
                        {
                            int min = (int)(weapon.minDamage.Value * Config.allWeaponSpinPercentDamage);
                            int max = (int)(weapon.maxDamage.Value * Config.allWeaponSpinPercentDamage);
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
                                who: player,
                                isProjectile: false
                            );
                        }
                    }

                    // Cut weeds (objects)
                    if (location.objects.TryGetValue(tile, out var obj) && obj.IsWeeds())
                    {
                        obj.performToolAction(weapon);
                        location.objects.Remove(tile);
                        Game1.playSound("cut");
                        Game1.createObjectDebris("771", (int)tile.X, (int)tile.Y, player.UniqueMultiplayerID);
                    }

                    // Cut grass (terrain features)
                    if (location.terrainFeatures.TryGetValue(tile, out var feature) && feature is Grass grass)
                    {
                        // Determine hay drop chance based on scythe type
                        double hayDropChance = isRegularScythe ? 0.5 : isGoldenScythe ? 0.75 : isIridiumScythe ? 1.0 : 0.0;

                        // Attempt to add hay to silos based on drop chance
                        if (random.NextDouble() < hayDropChance)
                        {
                            Game1.getFarm().tryToAddHay(1);

                            
                            int numSprites = 1;
                            double rotationSpeed = 0;
                            double baseRotation = 0;

                            TemporaryAnimatedSprite hay = new TemporaryAnimatedSprite();

                        
                            float orbitRadius = 48.0f;  //48


                            float offsetX = (float)Math.Cos(0.0) * orbitRadius;
                            float offsetY = (float)Math.Sin(0.0) * orbitRadius;
                            Vector2 orbitPos = tile + new Vector2(offsetX, offsetY);

                            string tileSheet = "Maps\\springobjects";

                            Rectangle sourceRect = new Rectangle(160, 112, 16, 16);


                            hay = new TemporaryAnimatedSprite(
                                tileSheet,
                                sourceRect, // First sword sprite
                                100f, 1, 1, orbitPos, flicker: false, flipped: false)
                                {
                                    rotation = (float)0.0,
                                    alpha = 0.4f,
                                    scale = 1.0f,
                                    motion = Vector2.Zero,
                                    layerDepth = 1f
                                };

                            if (hay != null)
                            {

                                Game1.currentLocation.temporarySprites.Add(hay);
                            }


                                
                                // StoreHayInAnySilo returns the amount of hay stored; if 0, silos are full
                                int hayStored = GameLocation.StoreHayInAnySilo(1, location);
                            if (hayStored >= 1)
                            {
                                Game1.showRedMessage(i18n.Get("ModEntry.Cs-showRedMessage.SiloAreFull"));
                            }
                        }

                        // Reduce or remove grass
                        if (grass.reduceBy(1, true))
                        {
                            location.terrainFeatures.Remove(tile);
                        }
                        Game1.playSound("cut");
                    }

                    // Harvest crops if using Iridium Scythe
                    if (isIridiumScythe)
                    {
                        if (location.terrainFeatures.TryGetValue(tile, out var terrainFeature) && terrainFeature is HoeDirt hoeDirt)
                        {
                            if (hoeDirt.crop != null && hoeDirt.readyForHarvest())
                            {
                                // Harvest the crop; the method returns a bool indicating success
                                bool harvested = hoeDirt.crop.harvest((int)tile.X, (int)tile.Y, hoeDirt, null, true);
                                if (harvested)
                                {
                                    hoeDirt.destroyCrop(showAnimation: true);
                                    Game1.playSound("harvest");
                                }
                            }
                        }
                    }
                }
            }
        }




        private void SpawnWeaponEffect(int radius)
        {

            Vector2 playerCenter = Game1.player.Position + new Vector2(Game1.player.Sprite.SpriteWidth / 2, -32f);
            int numSprites = Config.numberOfSpinningSprite;
            double rotationSpeed = -500;
            double baseRotation = Game1.ticks * rotationSpeed;

            TemporaryAnimatedSprite[] weaponEffect = new TemporaryAnimatedSprite[radius];

            for (int i = 0; i < numSprites; i++)
            {
                double angle = baseRotation + (Math.PI * 2 * i / numSprites);
                float orbitRadius = 48.0f;  //48


                float offsetX = (float)Math.Cos(angle) * orbitRadius;
                float offsetY = (float)Math.Sin(angle) * orbitRadius;
                Vector2 orbitPos = playerCenter + new Vector2(offsetX, offsetY);



                
                string weaponID = Game1.player.CurrentItem.GetItemTypeId() + Game1.player.CurrentItem.ItemId;
                WeaponSpriteData match = Config.weaponSpriteData
                    .FirstOrDefault(w => w.itemCategoryAndItemID == weaponID);
                
                string tileSheet = "TileSheets\\weapons";

                Rectangle sourceRect = new Rectangle(0, 0, 16, 16);
                string modID = null;
                int imageXpos = 0;
                int imageYpos = 0;
                Texture2D texture = null;
                if (match != null)
                {
                    tileSheet = match.tilesheetName;
                    sourceRect = match.SourceRect;

                  
                }



                for (int j = 0; j < weaponEffect.Length; j++)
                {
                    orbitRadius = 100 + (50 * j);
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

                    
                }



                


            }
        }

        private void SpawnToolEffect(Tool tool, int radius)
        {

            Vector2 playerCenter = Game1.player.Position + new Vector2(Game1.player.Sprite.SpriteWidth / 2, -32f);
            int numSprites = Config.numberOfSpinningSprite;
            double rotationSpeed = -500;
            double baseRotation = Game1.ticks * rotationSpeed;

            TemporaryAnimatedSprite[] axeEffect = new TemporaryAnimatedSprite[radius];
            TemporaryAnimatedSprite[] pickaxeEffect = new TemporaryAnimatedSprite[radius];
            TemporaryAnimatedSprite[] wateringcanEffect = new TemporaryAnimatedSprite[radius];
            TemporaryAnimatedSprite[] hoeEffect = new TemporaryAnimatedSprite[radius];


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
                else if (tool is WateringCan)
                {
                    string wateringcanID = Game1.player.CurrentItem.GetItemTypeId() + Game1.player.CurrentItem.ItemId;
                    WeaponSpriteData match = Config.weaponSpriteData
                        .FirstOrDefault(w => w.itemCategoryAndItemID == wateringcanID);

                    string tileSheet = "TileSheets\\tools";
                    Rectangle sourceRect = new Rectangle(48, 224, 16, 32);

                    if (match != null)
                    {
                        tileSheet = match.tilesheetName;
                        sourceRect = match.SourceRect;

                    }
                    //Console.WriteLine($"axeID: {axeID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");

                    for (int j = 0; j < wateringcanEffect.Length; j++)
                    {
                        orbitRadius = 100 + (50 * j);
                        offsetX = (float)Math.Cos(angle) * orbitRadius;
                        offsetY = (float)Math.Sin(angle) * orbitRadius;
                        orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                        wateringcanEffect[j] = new TemporaryAnimatedSprite(
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

                        if (wateringcanEffect[j] != null)
                        {
                            Game1.currentLocation.temporarySprites.Add(wateringcanEffect[j]);
                        }

                        //Console.WriteLine($"weaponID: {weaponID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
                    }


                }
                else if (tool is Hoe)
                {
                    string HoeID = Game1.player.CurrentItem.GetItemTypeId() + Game1.player.CurrentItem.ItemId;
                    WeaponSpriteData match = Config.weaponSpriteData
                        .FirstOrDefault(w => w.itemCategoryAndItemID == HoeID);

                    string tileSheet = "TileSheets\\tools";
                    Rectangle sourceRect = new Rectangle(192, 32, 16, 32);

                    if (match != null)
                    {
                        tileSheet = match.tilesheetName;
                        sourceRect = match.SourceRect;

                    }
                    //Console.WriteLine($"axeID: {axeID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");

                    for (int j = 0; j < hoeEffect.Length; j++)
                    {
                        orbitRadius = 100 + (50 * j);
                        offsetX = (float)Math.Cos(angle) * orbitRadius;
                        offsetY = (float)Math.Sin(angle) * orbitRadius;
                        orbitPos = playerCenter + new Vector2(offsetX, offsetY);
                        hoeEffect[j] = new TemporaryAnimatedSprite(
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

                        if (hoeEffect[j] != null)
                        {
                            Game1.currentLocation.temporarySprites.Add(hoeEffect[j]);
                        }

                        //Console.WriteLine($"weaponID: {weaponID} , tilesheet: {tileSheet} , sourceRect:{sourceRect}");
                    }


                }


            }
        }


        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            registerGMCM();
            RegisterUES();
            RegisterIconicFramework();
        }
        private void RegisterIconicFramework()
        {
            var iconicFramework = Helper.ModRegistry.GetApi<IIconicFrameworkApi>("furyx639.ToolbarIcons");
            if (iconicFramework is null)
            {
                Monitor.Log("Iconic Framework not found, skipping toolbar icon registration.", LogLevel.Info);
                return;
            }

            ITranslationHelper I18n = Helper.Translation;

            iconicFramework.AddToolbarIcon(
                id: $"{ModManifest.UniqueID}.Spin",
                texturePath: "Tilesheets/bobbers",
                    sourceRect: new Rectangle(50, 130, 11, 12), 
                getTitle: () => I18n.Get("Icon.Spin.name"),
                getDescription: () => I18n.Get("Icon.Spin.tooltip"),
                onClick: () => startSpinning(true)
            );




        }

        private void RegisterUES()
        {
            uesApi = Helper.ModRegistry.GetApi<UnifiedExperienceSystem.IUnifiedExperienceAPI>("Darkmushu.UnifiedExperienceSystem");

            if (uesApi == null)
            {
                return;
            }

            uesApi.RegisterAbility(
                 modUniqueId: this.ModManifest.UniqueID,
                 abilityId: "SpinningWeapon",
                 displayName: Helper.Translation.Get("ability.SpinningWeapon.name"),
                 description: Helper.Translation.Get("ability.SpinningWeapon.desc"),
                 curveKind: "step",
                 curveData: new Dictionary<string, object> { 
                     { "base", 100 },
                     { "step", 100 } 
                 },
                 maxLevel: 10
             );

            uesApi.RegisterAbility(
                modUniqueId: this.ModManifest.UniqueID,
                abilityId: "SpinningAxe",
                displayName: Helper.Translation.Get("ability.SpinningAxe.name"),
                description: Helper.Translation.Get("ability.SpinningAxe.desc"),
                 curveKind: "step",
                 curveData: new Dictionary<string, object> {
                     { "base", 100 },
                     { "step", 100 }
                 },
                 maxLevel: 10
            );

            uesApi.RegisterAbility(
                modUniqueId: this.ModManifest.UniqueID,
                abilityId: "SpinningPickAxe",
                displayName: Helper.Translation.Get("ability.SpinningPickAxe.name"),
                description: Helper.Translation.Get("ability.SpinningPickAxe.desc"),
                 curveKind: "step",
                 curveData: new Dictionary<string, object> {
                     { "base", 100 },
                     { "step", 100 }
                 },
                 maxLevel: 10
            );

            uesApi.RegisterAbility(
                modUniqueId: this.ModManifest.UniqueID,
                abilityId: "SpinningWateringCan",
                displayName: Helper.Translation.Get("ability.SpinningWateringCan.name"),
                description: Helper.Translation.Get("ability.SpinningWateringCan.desc"),
                 curveKind: "step",
                 curveData: new Dictionary<string, object> {
                     { "base", 100 },
                     { "step", 100 }
                 },
                 maxLevel: 10
            );

            uesApi.RegisterAbility(
                modUniqueId: this.ModManifest.UniqueID,
                abilityId: "SpinningHoe",
                displayName: Helper.Translation.Get("ability.SpinningHoe.name"),
                description: Helper.Translation.Get("ability.SpinningHoe.desc"),
                 curveKind: "step",
                 curveData: new Dictionary<string, object> {
                     { "base", 100 },
                     { "step", 100 }
                 },
                 maxLevel: 10
            );


        }

        private void registerGMCM()
        {

            // Uses Generic Mod Config Menu API to build a config UI.
            var gmcm = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (gmcm == null)
                return;

            // Register the mod.
            gmcm.Register(ModManifest, () => Config = new ModConfig(), () => Helper.WriteConfig(Config));

            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("config.description")
            );

            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("hotkeys.section")
            );

            gmcm.AddTextOption(
                mod: ModManifest,
                name: () => i18n.Get("config.mode.name"),
                tooltip: () => i18n.Get("config.mode.tooltip"),
                getValue: () => Config.Mode,
                setValue: value => Config.Mode = value,
                allowedValues: new[] { "Standalone", "UnifiedExperience" }
            );

            gmcm.AddTextOption(
                mod: ModManifest,
                name: () => i18n.Get("config.AbilityUses.name"),
                tooltip: () => i18n.Get("config.AbilityUses.tooltip"),
                getValue: () => Config.AbilityUses,
                setValue: value => Config.AbilityUses = value,
                allowedValues: new[] { "Energy", "Stamina" }
            );





        gmcm.AddKeybindList(
                ModManifest,
                name: () => i18n.Get("hotkeys.spin.name"),
                tooltip: () => i18n.Get("hotkeys.spin.tooltip"),
                getValue: () => Config.SpinHotkey,
                setValue: value => Config.SpinHotkey = value
            );

            gmcm.AddKeybindList(
                ModManifest,
                name: () => Helper.Translation.Get("gmcm.openMenu.name"),
                tooltip: () => Helper.Translation.Get("gmcm.openMenu.tooltip"),
                getValue: () => Config.OpenSkinMenu,
                setValue: value => Config.OpenSkinMenu = value
            );

            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("weapons_tools.section")
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.BaseStaminaDrain,
                setValue: value => Config.BaseStaminaDrain = value,
                name: () => i18n.Get("weapons_tools.stamina_drain.name"),
                tooltip: () => i18n.Get("weapons_tools.stamina_drain.tooltip"),
                min: 0.0f,
                max: 10.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfSpinningSprite,
                setValue: value => Config.numberOfSpinningSprite = value,
                name: () => i18n.Get("weapons_tools.spin_sprites.name"),
                tooltip: () => i18n.Get("weapons_tools.spin_sprites.tooltip"),
                min: 3,
                max: 20,
                interval: 1
            );



            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("weapons.section")
            );


            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForWeaponsPerLevel,
                setValue: value => Config.reduceStaminaDrainForWeaponsPerLevel = value,
                name: () => i18n.Get("weapons.stamina_reduction.name"),
                tooltip: () => i18n.Get("weapons.stamina_reduction.tooltip"),
                min: 0.00f,
                max: 1.0f,
                interval: 0.01f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.weaponSpinRadius,
                setValue: value => Config.weaponSpinRadius = value,
                name: () => i18n.Get("weapons.other_spin_radius.name"),
                tooltip: () => i18n.Get("weapons.other_spin_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.swordSpinRadius,
                setValue: value => Config.swordSpinRadius = value,
                name: () => i18n.Get("weapons.sword_spin_radius.name"),
                tooltip: () => i18n.Get("weapons.sword_spin_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.daggerSpinRadius,
                setValue: value => Config.daggerSpinRadius = value,
                name: () => i18n.Get("weapons.dagger_spin_radius.name"),
                tooltip: () => i18n.Get("weapons.dagger_spin_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.hammerSpinRadius,
                setValue: value => Config.hammerSpinRadius = value,
                name: () => i18n.Get("weapons.hammer_spin_radius.name"),
                tooltip: () => i18n.Get("weapons.hammer_spin_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.allWeaponSpinPercentDamage,
                setValue: value => Config.allWeaponSpinPercentDamage = value,
                name: () => i18n.Get("weapons.damage_percent.name"),
                tooltip: () => i18n.Get("weapons.damage_percent.tooltip"),
                min: 0.01f,
                max: 1.0f,
                interval: 0.01f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfWeaponSpinHitsPerSecond,
                setValue: value => Config.numberOfWeaponSpinHitsPerSecond = value,
                name: () => i18n.Get("weapons.hits_per_second.name"),
                tooltip: () => i18n.Get("weapons.hits_per_second.tooltip"),
                min: 1,
                max: 60,
                interval: 1
            );


            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("pickaxe.section")
            );


            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForPickaxePerLevel,
                setValue: value => Config.reduceStaminaDrainForPickaxePerLevel = value,
                name: () => i18n.Get("pickaxe.stamina_reduction.name"),
                tooltip: () => i18n.Get("pickaxe.stamina_reduction.tooltip"),
                min: 0.00f,
                max: 1.0f,
                interval: 0.01f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.pickaxeSpinRadius,
                setValue: value => Config.pickaxeSpinRadius = value,
                name: () => i18n.Get("pickaxe.spin_radius.name"),
                tooltip: () => i18n.Get("pickaxe.spin_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfPickaxeSpinHitsPerSecond,
                setValue: value => Config.numberOfPickaxeSpinHitsPerSecond = value,
                name: () => i18n.Get("pickaxe.hits_per_second.name"),
                tooltip: () => i18n.Get("pickaxe.hits_per_second.tooltip"),
                min: 1,
                max: 60,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.pickaxeSpinRadiusIncreaseByEachToolUpgradeLevel,
                setValue: value => Config.pickaxeSpinRadiusIncreaseByEachToolUpgradeLevel = value,
                name: () => i18n.Get("pickaxe.radius_per_upgrade.name"),
                tooltip: () => i18n.Get("pickaxe.radius_per_upgrade.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );


            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.pickaxeEnchantSwift,
                setValue: value => Config.pickaxeEnchantSwift = value,
                name: () => i18n.Get("pickaxe.swift_bonus_hits.name"),
                tooltip: () => i18n.Get("pickaxe.swift_bonus_hits.tooltip"),
                min: 1,
                max: 60,
                interval: 1
            );


            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("axe.section")
            );


            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForAxePerLevel,
                setValue: value => Config.reduceStaminaDrainForAxePerLevel = value,
                name: () => i18n.Get("axe.stamina_reduction.name"),
                tooltip: () => i18n.Get("axe.stamina_reduction.tooltip"),
                min: 0.00f,
                max: 1.0f,
                interval: 0.01f
            );
            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.axeSpinRadius,
                setValue: value => Config.axeSpinRadius = value,
                name: () => i18n.Get("axe.spin_radius.name"),
                tooltip: () => i18n.Get("axe.spin_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.axeSpinRadiusIncreaseByEachToolUpgradeLevel,
                setValue: value => Config.axeSpinRadiusIncreaseByEachToolUpgradeLevel = value,
                name: () => i18n.Get("axe.radius_per_upgrade.name"),
                tooltip: () => i18n.Get("axe.radius_per_upgrade.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.numberOfAxeSpinHitsPerSecond,
                setValue: value => Config.numberOfAxeSpinHitsPerSecond = value,
                name: () => i18n.Get("axe.hits_per_second.name"),
                tooltip: () => i18n.Get("axe.hits_per_second.tooltip"),
                min: 1,
                max: 60,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.axeEnchantSwift,
                setValue: value => Config.axeEnchantSwift = value,
                name: () => i18n.Get("axe.swift_bonus_hits.name"),
                tooltip: () => i18n.Get("axe.swift_bonus_hits.tooltip"),
                min: 1,
                max: 60,
                interval: 1
            );


            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("watering_can.section")
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.wateringcanRadius,
                setValue: value => Config.wateringcanRadius = value,
                name: () => i18n.Get("watering_can.base_radius.name"),
                tooltip: () => i18n.Get("watering_can.base_radius.tooltip"),
                min: 1,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.wateringcanSpinRadiusIncreaseByEachToolUpgradeLevel,
                setValue: value => Config.wateringcanSpinRadiusIncreaseByEachToolUpgradeLevel = value,
                name: () => i18n.Get("watering_can.radius_per_upgrade.name"),
                tooltip: () => i18n.Get("watering_can.radius_per_upgrade.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );
            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForWateringCanPerLevel,
                setValue: value => Config.reduceStaminaDrainForWateringCanPerLevel = value,
                name: () => i18n.Get("watering_can.stamina_reduction.name"),
                tooltip: () => i18n.Get("watering_can.stamina_reduction.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.wateringcanEnchantReaching,
                setValue: value => Config.wateringcanEnchantReaching = value,
                name: () => i18n.Get("watering_can.reaching_bonus_radius.name"),
                tooltip: () => i18n.Get("watering_can.reaching_bonus_radius.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.wateringcanEnchantEfficient,
                setValue: value => Config.wateringcanEnchantEfficient = value,
                name: () => i18n.Get("wateringcan.enchant_efficient.name"),
                tooltip: () => i18n.Get("wateringcan.enchant_efficient.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddParagraph(
                ModManifest,
                text: () => i18n.Get("hoe.section")
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.HoeRadius,
                setValue: value => Config.HoeRadius = value,
                name: () => i18n.Get("hoe.base_radius.name"),
                tooltip: () => i18n.Get("hoe.base_radius.tooltip"),
                min: 0,
                max: 20,
                interval: 1
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.HoeSpinRadiusIncreaseByEachToolUpgradeLevel,
                setValue: value => Config.HoeSpinRadiusIncreaseByEachToolUpgradeLevel = value,
                name: () => i18n.Get("hoe.radius_per_upgrade.name"),
                tooltip: () => i18n.Get("hoe.radius_per_upgrade.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );
            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.reduceStaminaDrainForHoePerLevel,
                setValue: value => Config.reduceStaminaDrainForHoePerLevel = value,
                name: () => i18n.Get("hoe.reduced_stamina_per_level.name"),
                tooltip: () => i18n.Get("hoe.reduced_stamina_per_level.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.HoeEnchantReaching,
                setValue: value => Config.HoeEnchantReaching = value,
                name: () => i18n.Get("hoe.enchant_reaching.name"),
                tooltip: () => i18n.Get("hoe.enchant_reaching.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.HoeEnchantEfficient,
                setValue: value => Config.HoeEnchantEfficient = value,
                name: () => i18n.Get("hoe.enchant_efficient.name"),
                tooltip: () => i18n.Get("hoe.enchant_efficient.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );

            gmcm.AddNumberOption(
                mod: ModManifest,
                getValue: () => Config.HoeEnchantSwift,
                setValue: value => Config.HoeEnchantSwift = value,
                name: () => i18n.Get("hoe.enchant_swift.name"),
                tooltip: () => i18n.Get("hoe.enchant_swift.tooltip"),
                min: 0.0f,
                max: 3.0f,
                interval: 0.1f
            );



        }


    }


}


