using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class hadroncheat : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 20;

            item.value = 60000;
            item.rare = 1;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault(":^)");
      Tooltip.SetDefault("Immune to hadron's cooldown");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.buffImmune[mod.BuffType("HadronCooldown")] = true;
        }
    }
}
