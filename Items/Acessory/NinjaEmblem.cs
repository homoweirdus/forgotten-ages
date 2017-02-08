using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class NinjaEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ninja Emblem";
            item.width = 14;
            item.height = 14;
            item.toolTip = "Increases Thrown Damage by 15%.";
            item.value = 100000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;
        }
    }
}