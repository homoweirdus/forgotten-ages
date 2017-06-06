using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class JaggedBand : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 14;
            item.height = 14;

            item.value = 100000;
            item.rare = 9;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Jagged Band");
      Tooltip.SetDefault("75% increase to all damage but summon, but you take 150% more damage");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance -= 1.5f;
			player.meleeDamage += 0.75f;
			player.rangedDamage += 0.75f;
			player.magicDamage += 0.75f;
			player.thrownDamage += 0.75f;
        }
    }
}
