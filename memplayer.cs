using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraUI;
using TerraUI.Objects;
using TerraUI.Utilities;

namespace ForgottenMemories {
    internal class memplayer : ModPlayer {
        private const string HIDDEN_TAG = "hidden";
        private const string SOULS_TAG = "souls";
        private const string VANITY_SOULS_TAG = "vanitysouls";
        private const string SOUL_DYE_TAG = "souldye";
        private const string SOUL_DYE_LAYER = "SoulDye";
        private PlayerLayer soulsDye;

        public UIItemSlot EquipSoulSlot;
        public UIItemSlot VanitySoulSlot;
        public UIItemSlot SoulDyeSlot;

        public override bool Autoload(ref string name) {
            return true;
        }

        public override void Initialize() {
            EquipSoulSlot = new UIItemSlot(Vector2.Zero, context: Contexts.EquipAccessory,
                conditions: Slot_Conditions, drawBackground: Slot_DrawBackground,
                scaleToInventory: true);
            VanitySoulSlot = new UIItemSlot(Vector2.Zero, context: Contexts.EquipAccessoryVanity,
                conditions: Slot_Conditions, drawBackground: Slot_DrawBackground,
                scaleToInventory: true);
            SoulDyeSlot = new UIItemSlot(Vector2.Zero, context: Contexts.EquipDye,
                conditions: SoulDyeSlot_Conditions, drawBackground: SoulDyeSlot_DrawBackground,
                scaleToInventory: true);
            VanitySoulSlot.Partner = EquipSoulSlot;

            // Big thanks to thegamemaster1234 for the example code used to write this!
            soulsDye = new PlayerLayer(UIUtils.Mod.Name, SOUL_DYE_LAYER, delegate (PlayerDrawInfo drawInfo) {
                Player player = drawInfo.drawPlayer;
                memplayer wsp = player.GetModPlayer<memplayer>(UIUtils.Mod);
                Item souls = wsp.GetDyedSouls();
                Item dye = wsp.SoulDyeSlot.Item;
                int index = Main.playerDrawData.Count - 1;
                
                if(dye.stack <= 0 || souls.stack <= 0 || !souls.active || souls.noUseGraphic || player.mount.Active || 
                  (wsp.VanitySoulSlot.Item.stack <= 0 && !wsp.EquipSoulSlot.ItemVisible && player.wingFrame == 0))
                    return;

                if(souls.flame)
                    index -= 1;

                if(index < 0 || index > Main.playerDrawData.Count)
                    return;

                DrawData data = Main.playerDrawData[index];
                data.shader = dye.dye;
                Main.playerDrawData[index] = data;
            });

            InitializeSouls();
        }

        private void Slot_DrawBackground(UIObject sender, SpriteBatch spriteBatch) {
            UIItemSlot slot = (UIItemSlot)sender;

            if(ShouldDrawSlots()) {
                slot.OnDrawBackground(spriteBatch);

                if(slot.Item.stack == 0) {
                    Texture2D tex = mod.GetTexture(ForgottenMemories.soulbackround);
                    Vector2 origin = tex.Size() / 2f * Main.inventoryScale;
                    Vector2 position = slot.Rectangle.TopLeft();

                    spriteBatch.Draw(
                        tex,
                        position + (slot.Rectangle.Size() / 2f) - (origin / 2f),
                        null,
                        Color.White * 0.15f,
                        0f,
                        origin,
                        Main.inventoryScale,
                        SpriteEffects.None,
                        0f); // layer depth 0 = front
                }
            }
        }

        private bool Slot_Conditions(Item item) {
            if(item.toolTip2 == "Compatible with Forgotten Memories") {
                return true;
            }
            return false;
        }

        private void SoulDyeSlot_DrawBackground(UIObject sender, SpriteBatch spriteBatch) {
            UIItemSlot slot = (UIItemSlot)sender;

            if(ShouldDrawSlots()) {
                slot.OnDrawBackground(spriteBatch);

                if(slot.Item.stack == 0) {
                    Texture2D tex = Main.extraTexture[54];
                    Rectangle rectangle = tex.Frame(3, 6, 1 % 3, 1 / 3);
                    rectangle.Width -= 2;
                    rectangle.Height -= 2;
                    Vector2 origin = rectangle.Size() / 2f * Main.inventoryScale;
                    Vector2 position = slot.Rectangle.TopLeft();

                    spriteBatch.Draw(
                        tex,
                        position + (slot.Rectangle.Size() / 2f) - (origin / 2f),
                        new Rectangle?(rectangle),
                        Color.White * 0.35f,
                        0f,
                        origin,
                        Main.inventoryScale,
                        SpriteEffects.None,
                        0f); // layer depth 0 = front
                }
            }
        }

        private bool SoulDyeSlot_Conditions(Item item) {
            if(item.dye > 0 && item.hairDye < 0) {
                return true;
            }
            return false;
        }

        public override void PreUpdate() {
            if(ShouldDrawSlots()) {
                EquipSoulSlot.Update();
                VanitySoulSlot.Update();
                SoulDyeSlot.Update();
            }

            UIUtils.UpdateInput();

            base.PreUpdate();
        }

        public override void ModifyDrawLayers(List<PlayerLayer> layers) {
            if(!Main.gameMenu) {
                layers.Insert(layers.IndexOf(PlayerLayer.Wings) + 1, soulsDye);
            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
            Item souls = EquipSoulSlot.Item;
            Item vanitySouls = VanitySoulSlot.Item;

            if(souls.stack > 0) {
                player.VanillaUpdateEquip(souls);
                player.VanillaUpdateAccessory(player.whoAmI, souls, !EquipSoulSlot.ItemVisible, ref wallSpeedBuff, ref tileSpeedBuff,
                    ref tileRangeBuff);
            }

            if(vanitySouls.stack > 0) {
                player.VanillaUpdateVanityAccessory(vanitySouls);
            }
        }

        public override TagCompound Save() {
            return new TagCompound {
                { HIDDEN_TAG, EquipSoulSlot.ItemVisible },
                { SOULS_TAG, ItemIO.Save(EquipSoulSlot.Item) },
                { VANITY_SOULS_TAG, ItemIO.Save(VanitySoulSlot.Item) },
                { SOUL_DYE_TAG, ItemIO.Save(SoulDyeSlot.Item) }
            };
        }

        public override void Load(TagCompound tag) {
            SetSouls(false, ItemIO.Load(tag.GetCompound(SOULS_TAG)));
            SetSouls(true, ItemIO.Load(tag.GetCompound(VANITY_SOULS_TAG)));
            SetDye(ItemIO.Load(tag.GetCompound(SOUL_DYE_TAG)));
            EquipSoulSlot.ItemVisible = tag.GetBool(HIDDEN_TAG);
        }

        public override void LoadLegacy(BinaryReader reader) {
            int hide = 0;

            InitializeSouls();

            ushort installedFlag = reader.ReadUInt16();

            if(installedFlag == 0) {
                try { hide = reader.ReadInt32(); }
                catch(EndOfStreamException) { hide = 0; }

                EquipSoulSlot.ItemVisible = (hide == 1 ? false : true);

                Item souls1 = EquipSoulSlot.Item;
                Item souls2 = VanitySoulSlot.Item;

                int context = ReadSoulsLegacy(ref souls1, reader);
                ReadSoulsLegacy(ref souls2, reader);

                if(context == (int)Contexts.EquipAccessory) {
                    SetSouls(false, souls1);
                    SetSouls(true, souls2);
                }
                else if(context == (int)Contexts.EquipAccessoryVanity) {
                    SetSouls(true, souls1);
                    SetSouls(false, souls2);
                }
            }
        }

        internal static int ReadSoulsLegacy(ref Item souls, BinaryReader reader) {
            try {
                ItemIO.LoadLegacy(souls, reader, false, false);
                return reader.ReadInt32();
            }
            catch(EndOfStreamException) {
                return -1;
            }
        }

        /// <summary>
        /// Initialize the items in the UIItemSlots.
        /// </summary>
        private void InitializeSouls() {
            EquipSoulSlot.Item = new Item();
            VanitySoulSlot.Item = new Item();
            SoulDyeSlot.Item = new Item();
            EquipSoulSlot.Item.SetDefaults();
            VanitySoulSlot.Item.SetDefaults();
            SoulDyeSlot.Item.SetDefaults();
        }

        /// <summary>
        /// Set the item in the specified slot.
        /// </summary>
        /// <param name="isVanity">whether to equip in the vanity slot</param>
        /// <param name="item">souls</param>
        public void SetSouls(bool isVanity, Item item) {
            if(!isVanity) {
                EquipSoulSlot.Item = item.Clone();
            }
            else {
                VanitySoulSlot.Item = item.Clone();
            }
        }

        /// <summary>
        /// Clear the souls from the specified slot.
        /// </summary>
        /// <param name="isVanity">whether to unequip from the vanity slot</param>
        public void ClearSouls(bool isVanity) {
            if(!isVanity) {
                EquipSoulSlot.Item = new Item();
                EquipSoulSlot.Item.SetDefaults();
            }
            else {
                VanitySoulSlot.Item = new Item();
                VanitySoulSlot.Item.SetDefaults();
            }
        }

        /// <summary>
        /// Set the soul dye.
        /// </summary>
        /// <param name="item">dye</param>
        public void SetDye(Item item) {
            SoulDyeSlot.Item = item.Clone();
        }

        /// <summary>
        /// Clear the soul dye.
        /// </summary>
        public void ClearDye() {
            SoulDyeSlot.Item = new Item();
            SoulDyeSlot.Item.SetDefaults();
        }

        /// <summary>
        /// Equip a set of souls.
        /// </summary>
        /// <param name="isVanity">whether the souls should go in the vanity slot</param>
        /// <param name="item">souls</param>
        public void EquipSouls(bool isVanity, Item item) {
            UIItemSlot slot = (isVanity ? VanitySoulSlot : EquipSoulSlot);
            int fromSlot = Array.FindIndex(player.inventory, i => i == item);

            // from inv to slot
            if(fromSlot > -1) {
                item.favorited = false;
                player.inventory[fromSlot] = slot.Item.Clone();
                UIUtils.PlaySound(Sounds.Grab);
                Recipe.FindRecipes();
                SetSouls(isVanity, item);
            }
        }

        /// <summary>
        /// Whether to draw the UIItemSlots.
        /// </summary>
        /// <returns>whether to draw the slots</returns>
        public bool ShouldDrawSlots() {
            if(Main.playerInventory && Main.EquipPage == 2) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Equip a dye.
        /// </summary>
        /// <param name="item">dye to equip</param>
        public void EquipDye(Item item) {
            int fromSlot = Array.FindIndex(player.inventory, i => i == item);

            // from inv to slot
            if(fromSlot > -1) {
                item.favorited = false;
                player.inventory[fromSlot] = SoulDyeSlot.Item.Clone();
                UIUtils.PlaySound(Sounds.Grab);
                Recipe.FindRecipes();
                SetDye(item);
            }
        }

        /// <summary>
        /// Get the set of souls that a dye should be applied to.
        /// </summary>
        /// <returns>dyed souls</returns>
        public Item GetDyedSouls() {
            if(VanitySoulSlot.Item.stack > 0) {
                return VanitySoulSlot.Item;
            }
            else if(EquipSoulSlot.Item.stack > 0) {
                return EquipSoulSlot.Item;
            }

            return new Item();
        }
    }
}
