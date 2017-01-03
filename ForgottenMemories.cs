using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories {
    public class ForgottenMemories : Mod {
        public const string soulbackround = "soulbackround";
		public ForgottenMemories()

 {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadSounds = true,
				AutoloadGores = true
            };

            TerraUI.Utilities.UIUtils.Mod = this;
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch) {
            DrawSlots(spriteBatch);
            base.PostDrawInterface(spriteBatch);
        }

        /// <summary>
        /// Draws the soul equipment slots.
        /// Based on code provided by jopojelly.
        /// </summary>
        private void DrawSlots(SpriteBatch spriteBatch) {
            memplayer mp = Main.player[Main.myPlayer].GetModPlayer<memplayer>(this);

            if(mp.ShouldDrawSlots()) {

                int mapH = 0;
                int rX = 0;
                int rY = 0;
                float origScale = Main.inventoryScale;

                Main.inventoryScale = 0.85f;

                if(Main.mapEnabled) {
                    if(!Main.mapFullscreen && Main.mapStyle == 1) {
                        mapH = 256;
                    }

                    if((mapH + 600) > Main.screenHeight) {
                        mapH = Main.screenHeight - 600;
                    }
                }

                rX = Main.screenWidth - 92 - (47 * 2);
                rY = mapH + 174;

                if(Main.netMode == 1) {
                    rX -= 47;
                }

                mp.EquipSoulSlot.Position = new Vector2(rX, rY += 47);
                mp.VanitySoulSlot.Position = new Vector2(rX -= 47, rY);
                mp.SoulDyeSlot.Position = new Vector2(rX -= 47, rY);

                mp.VanitySoulSlot.Draw(spriteBatch);
                mp.EquipSoulSlot.Draw(spriteBatch);
                mp.SoulDyeSlot.Draw(spriteBatch);

                Main.inventoryScale = origScale;
            }
        }
    }
}
