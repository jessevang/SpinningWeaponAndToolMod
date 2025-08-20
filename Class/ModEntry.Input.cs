using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Enchantments;
using StardewValley.Tools;



namespace SpinningWeaponAndToolMod
{
    public partial class ModEntry
    {
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {

            //Return if world hasn't been loaded
            if (!Context.IsWorldReady)
                return;

            if (Config.OpenSkinMenu.JustPressed())
            {
                Game1.activeClickableMenu = new ModImagePreviewer(Instance, Config, i18n);
            }

            startSpinning(false);

        }

        public void startSpinning(bool usedIconToTrigger)
        {
            //Return if world hasn't been loaded
            if (!Context.IsWorldReady)
                return;

            
            //IconicFrameworkButtonPressCount = 1 click once, IconicFrameworkButtonPressCount = 2 should mean release button or clicked twice
            if (usedIconToTrigger == true)
            {
                IconicFrameworkButtonPressCount++;
            }

            if (IconicFrameworkButtonPressCount == 2)
            {
                //reset clicks
                IconicFrameworkButtonPressCount =0;
                //stop spin
                if (isSpinning && usedIconToTrigger)
                {
                    StopSpinning();
                }

            }
            



                Tool tool = Game1.player.CurrentTool;


            if ((Config.SpinHotkey.JustPressed()|| (usedIconToTrigger && IconicFrameworkButtonPressCount==1)) && tool is not null &&
                (tool is Pickaxe || tool is Axe || tool is WateringCan || tool is Hoe || (tool is MeleeWeapon weapon)))
            {
                AbilityReduceStaminaDrainBy = Config.BaseStaminaDrain;
                spinningTool = tool;
                //If Unified Experience Mode is turned on and API is registered and reduce config stamina drain
                if (GoodToRunUnifiedExperienceSystem())
                {
                    if (tool is Pickaxe)
                    {
                        SpinningPickAxeLevel = uesApi.GetAbilityLevel(ModManifest.UniqueID, "SpinningPickaxe");
                        AbilityReduceStaminaDrainBy = Config.BaseStaminaDrain - ((Config.BaseStaminaDrain * 0.1f) * SpinningPickAxeLevel);
                        //Monitor.Log($"Config: {Config.BaseStaminaDrain} - Config {Config.BaseStaminaDrain} * float value * {SpinningPickAxeLevel}", LogLevel.Debug);
                        AbilityIncreaseSpinRadiusBy = (int)(SpinningPickAxeLevel / 5);

                        if (SpinningPickAxeLevel > 0)
                            isSpinning = true;
                    }

                    else if (tool is Axe)
                    {

                        SpinningAxeLevel = uesApi.GetAbilityLevel(ModManifest.UniqueID, "SpinningAxe");
                        AbilityReduceStaminaDrainBy = Config.BaseStaminaDrain - ((Config.BaseStaminaDrain * 0.1f) * SpinningAxeLevel);
                        AbilityIncreaseSpinRadiusBy = (int)(SpinningAxeLevel / 5);
                        if (SpinningAxeLevel > 0)
                            isSpinning = true;
                    }

                    else if (tool is MeleeWeapon)
                    {
                        SpinningWeaponLevel = uesApi.GetAbilityLevel(ModManifest.UniqueID, "SpinningWeapon");
                        AbilityReduceStaminaDrainBy = Config.BaseStaminaDrain - ((Config.BaseStaminaDrain * 0.1f) * SpinningWeaponLevel);
                        AbilityIncreaseSpinRadiusBy = (int)(SpinningWeaponLevel / 5);
                        if (SpinningWeaponLevel > 0)
                            isSpinning = true;
                    }

                    else if (tool is WateringCan)
                    {
                        SpinningWateringCanLevel = uesApi.GetAbilityLevel(ModManifest.UniqueID, "SpinningWateringCan");
                        AbilityReduceStaminaDrainBy = Config.BaseStaminaDrain - ((Config.BaseStaminaDrain * 0.1f) * SpinningWateringCanLevel);
                        AbilityIncreaseSpinRadiusBy = (int)(SpinningWateringCanLevel / 5);

                        if (SpinningWateringCanLevel > 0)
                            isSpinning = true;
                    }

                    else if (tool is Hoe)
                    {
                        SpinningHoeLevel = uesApi.GetAbilityLevel(ModManifest.UniqueID, "SpinningHoe");
                        AbilityReduceStaminaDrainBy = Config.BaseStaminaDrain - ((Config.BaseStaminaDrain * 0.1f) * SpinningHoeLevel);
                        AbilityIncreaseSpinRadiusBy = (int)(SpinningHoeLevel / 5);
      
                        if (SpinningHoeLevel > 0)
                            isSpinning = true;
                    }




                }
                else //We still need to allow this to work even if not good to run unified experience system or as Standalone
                {
                    isSpinning = true;
                }



                weaponSpinTickCounter = 0;
                axeSpinTickCounter = 0;
                pickaxeSpinTickCounter = 0;
                rotateTickCounter = 0;
                facingDirectionIndex = 0;
                wateringcanSpinTickCounter = 0;
                hoeSpinTickCounter = 0;

                Game1.player.UsingTool = false;
                Game1.player.completelyStopAnimatingOrDoingAction();
            }
        }

        private void OnButtonReleased(object sender, ButtonReleasedEventArgs e)
        {
            if (!Context.IsWorldReady) return;

            if ((Config.SpinHotkey.GetState() == SButtonState.Released) && isSpinning)
            {
                StopSpinning();
            }
        }


        public bool GoodToRunUnifiedExperienceSystem()
        {
            if (Config.Mode == "UnifiedExperience" && uesApi != null)
            {
                return true;
            }
            return false;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {

            if (!Context.IsWorldReady || !isSpinning) return;


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


            if (Game1.player.CurrentTool != spinningTool)
            {
                if (isSpinning)
                {
                    StopSpinning();
                }
                return;
            }
               


            //checks for stamina if not enough won't spin or run any additiona code


            staminaDrainCounter++;
            if (staminaDrainCounter >= 6 && Config.AbilityUses.Equals("Stamina"))
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

            if (staminaDrainCounter >= 6 && Config.AbilityUses.Equals("Energy"))
            {
                staminaDrainCounter = 0;
                float EnergyCost = Config.BaseStaminaDrain;
                float currentEnergy = uesApi?.GetCurrentEnergy() ?? 0;

                if (currentEnergy < EnergyCost)
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
            if (Game1.player.CurrentTool is WateringCan)
            {
                wateringcanSpinTickCounter++;

            }
            if (Game1.player.CurrentTool is Hoe)
            {
                hoeSpinTickCounter++;
            }

            int maxWateringCanSpinTickCounter = 0;
            maxWateringCanSpinTickCounter = (60 / 3);

            

            

            if (wateringcanSpinTickCounter >= maxWateringCanSpinTickCounter && Game1.player.CurrentTool is WateringCan wateringCan)
            {
                int waterLeft = wateringCan.WaterLeft;

                wateringcanSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                float playerfarmingLevel = Game1.player.FarmingLevel * Config.reduceStaminaDrainForWateringCanPerLevel;
                wateringCan.WaterLeft = waterLeft - 1;
                if (Game1.player.CurrentTool.hasEnchantmentOfType<EfficientToolEnchantment>())
                {
                    playerfarmingLevel = (Game1.player.FarmingLevel * Config.reduceStaminaDrainForWateringCanPerLevel) + Config.wateringcanEnchantEfficient;
                }

                if (Config.AbilityUses.Equals("Stamina"))
                    Game1.player.Stamina -= Math.Max(AbilityReduceStaminaDrainBy - playerfarmingLevel, 0.1f);

                if (Config.AbilityUses.Equals("Energy"))
                {
                    if (uesApi != null)
                    {
                        float energyCost = Math.Max(AbilityReduceStaminaDrainBy - playerfarmingLevel, 0.1f);
                        bool used = uesApi.TryToUseAbility(energyCost);
                    }
                }
            }




            int maxhoeSpinTickCounter = 0;
            if (Game1.player.CurrentTool is Hoe tempHoe && tempHoe.hasEnchantmentOfType<SwiftToolEnchantment>())
            {
                maxhoeSpinTickCounter = (int)(60 / (Config.numberOfHoeSpinHitsPerSecond + Config.HoeEnchantSwift));
            }
            else
            {
                maxhoeSpinTickCounter = (60 / Config.numberOfHoeSpinHitsPerSecond);
            }

            if (hoeSpinTickCounter >= maxhoeSpinTickCounter)
            {


                hoeSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                float playerfarmingLevel = Game1.player.FarmingLevel * Config.reduceStaminaDrainForHoePerLevel;
                if (Game1.player.CurrentTool.hasEnchantmentOfType<EfficientToolEnchantment>())
                {
                    playerfarmingLevel = (Game1.player.FarmingLevel * Config.reduceStaminaDrainForHoePerLevel) + Config.HoeEnchantEfficient;
                }
                if (Config.AbilityUses.Equals("Stamina"))
                    Game1.player.Stamina -= Math.Max(AbilityReduceStaminaDrainBy - playerfarmingLevel, 0.1f);
                if (Config.AbilityUses.Equals("Energy"))
                {
                    if (uesApi != null)
                    {
                        float energyCost = Math.Max(AbilityReduceStaminaDrainBy - playerfarmingLevel , 0.1f);
                        bool used = uesApi.TryToUseAbility(energyCost);

                        
    
                    }

                }

            }






            int pickaxeTicksToSpin = 0;
            if (Game1.player.CurrentTool is Pickaxe tempPickaxe && tempPickaxe.hasEnchantmentOfType<SwiftToolEnchantment>())
            {
                pickaxeTicksToSpin = (int)(60 / (Config.numberOfAxeSpinHitsPerSecond + Config.pickaxeEnchantSwift));
            }
            else
            {
                pickaxeTicksToSpin = (60 / Config.numberOfPickaxeSpinHitsPerSecond);
            }

            if (pickaxeSpinTickCounter >= pickaxeTicksToSpin)
            {


                pickaxeSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                float playerMiningLevel = Game1.player.MiningLevel * Config.reduceStaminaDrainForPickaxePerLevel;
                if (Game1.player.CurrentTool.hasEnchantmentOfType<EfficientToolEnchantment>())
                {
                    playerMiningLevel = (Game1.player.MiningLevel * Config.reduceStaminaDrainForPickaxePerLevel) + Config.pickaxeEnchantEfficient;
                }
                if (Config.AbilityUses.Equals("Stamina"))
                    Game1.player.Stamina -= Math.Max(AbilityReduceStaminaDrainBy - playerMiningLevel, 0.1f);
                if (Config.AbilityUses.Equals("Energy"))
                {
                    if (uesApi != null)
                    {
                        float energyCost = Math.Max(AbilityReduceStaminaDrainBy - playerMiningLevel , 0.1f);
                        bool used = uesApi.TryToUseAbility(energyCost);
                        //Monitor.Log($"Energy cost: {energyCost} = config: {Config.BaseStaminaDrain} - playerfarminglevel{playerMiningLevel} - AbilityReductionStaminaDrainBy {AbilityReduceStaminaDrainBy}. or 0.1f", LogLevel.Debug);
                    }

                }

            }


            int axeTicksToSpin = 0;
            if (Game1.player.CurrentTool is Axe tempAxe && tempAxe.hasEnchantmentOfType<SwiftToolEnchantment>())
            {
                axeTicksToSpin = (int)(60 / (Config.numberOfAxeSpinHitsPerSecond + Config.pickaxeEnchantEfficient));
            }
            else
            {
                axeTicksToSpin = (60 / Config.numberOfAxeSpinHitsPerSecond);
            }


            if (axeSpinTickCounter >= axeTicksToSpin)
            {
                axeSpinTickCounter = 0;
                startSpinAnimation = true;
                float startStamina = Game1.player.Stamina;
                ApplySpinEffect();
                Game1.player.Stamina = startStamina;
                float playerForgageLevel = Game1.player.ForagingLevel * Config.reduceStaminaDrainForAxePerLevel;

                if (Game1.player.CurrentTool.hasEnchantmentOfType<EfficientToolEnchantment>())
                {
                    playerForgageLevel = (Game1.player.ForagingLevel * Config.reduceStaminaDrainForAxePerLevel) + Config.axeEnchantEfficient;
                }
                if (Config.AbilityUses.Equals("Stamina"))
                    Game1.player.Stamina -= Math.Max(AbilityReduceStaminaDrainBy - playerForgageLevel, 0.1f);
                if (Config.AbilityUses.Equals("Energy"))
                {
                    if (uesApi != null)
                    {
                        float energyCost = Math.Max(AbilityReduceStaminaDrainBy - playerForgageLevel, 0.1f);
                        bool used = uesApi.TryToUseAbility(energyCost);
                    }

                }
                //Console.WriteLine($"playerForgageLevel  *.1: {playerForgageLevel} ");

            }
            if ((weaponSpinTickCounter >= (60 / Config.numberOfWeaponSpinHitsPerSecond)))
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


                    Game1.player.Stamina -= Math.Max(AbilityReduceStaminaDrainBy - playerCombatLevel, 0.1f);
                    //Console.WriteLine($"playerCombatLevel  *.1: {playerCombatLevel} ");
                }


            }

            if (startSpinAnimation)
            {
                ApplySpinAnimation();
                ForceSpinAnimation(Game1.player.FacingDirection);

            }


            //weapon and tool check
            if (!Context.IsPlayerFree) return;

            Item currentItem = Game1.player.CurrentItem;

            if (currentItem is not Tool && currentItem is not MeleeWeapon)
                return;

            string itemKey = currentItem.Name + "_" + currentItem.GetItemTypeId() + currentItem.ItemId;

            // Only process new items
            if (itemKey == lastItemKey)
                return;

            lastItemKey = itemKey;

            // Build weapon ID to match your config system
            string itemCategoryAndItemID = currentItem.GetItemTypeId() + currentItem.ItemId;

            // Check if already exists in config
            if (Config.weaponSpriteData.Any(w => w.itemCategoryAndItemID == itemCategoryAndItemID))
            {
                //Monitor.Log($"Already in config: {itemKey}", LogLevel.Trace);
                return;
            }

            // Get default texture info (fallback is TileSheets)
            string tilesheetName = "TileSheets\\tools";
            Rectangle sourceRect = new Rectangle(0, 0, 16, 16);

            if (currentItem is MeleeWeapon weapon)
            {
                tilesheetName = "TileSheets\\weapons";
                int index = weapon.CurrentParentTileIndex;
                sourceRect = Game1.getSourceRectForStandardTileSheet(
                    Game1.content.Load<Texture2D>(tilesheetName), index, 16, 16);
            }
            else if (currentItem is Tool tool)
            {
                tilesheetName = "TileSheets\\tools";
                int index = tool.CurrentParentTileIndex;
                sourceRect = Game1.getSourceRectForStandardTileSheet(
                    Game1.content.Load<Texture2D>(tilesheetName), index, 16, 16);
            }

            // Create a new entry and add it
            var newEntry = new WeaponSpriteData
            {
                ItemName = currentItem.Name,
                itemCategoryAndItemID = itemCategoryAndItemID,
                tilesheetName = tilesheetName,
                SourceRect = sourceRect
            };

            Config.weaponSpriteData.Add(newEntry);
            Helper.WriteConfig(Config);

            Monitor.Log($"[AutoConfig] Added new item to config: {currentItem.Name} ({itemCategoryAndItemID})", LogLevel.Info);



        }

    }
}
