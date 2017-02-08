using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class BandOFlight : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Band of Flight";
            item.width = 14;
            item.height = 10;
            item.toolTip = "Contains the blessings of the sky.";
            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }

		
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = (int)(player.wingTimeMax * 1.5);
        }
    }
}