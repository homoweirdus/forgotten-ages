using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ModLoader;
using TerraUI.Utilities;

namespace ForgottenMemories {
    class GlobalsoulItem : GlobalItem {
        public override bool Autoload(ref string name) {
            return true;
        }

        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame,
            Color drawColor, Color itemColor, Vector2 origin, float scale) {
            base.PostDrawInInventory(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
        }

        public override bool CanEquipAccessory(Item item, Player player, int slot) {
            if(item.accessory == true) {
                return true;
            }
            return base.CanEquipAccessory(item, player, slot);
        }

        public override bool CanRightClick(Item item) {
            if(item.toolTip2 == "Compatible with Forgotten Memories") {
                return true;
            }

            return base.CanRightClick(item);
        }

        public override void RightClick(Item item, Player player) {
            if(item.toolTip2 == "Compatible with Forgotten Memories") {
                memplayer mp = player.GetModPlayer<memplayer>(mod);

                if(KeyboardUtils.HeldDown(Keys.LeftShift)) {
                    mp.EquipSouls(true, item);
                }
                else {
                    mp.EquipSouls(false, item);
                }
            }
            else {
                base.RightClick(item, player);
            }
        }
    }
}
