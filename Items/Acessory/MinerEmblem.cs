using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class MinerEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Miner Emblem";
            item.width = 14;
            item.height = 14;
            item.toolTip = "Increases mining speed by 25%";
            item.value = 100000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.pickSpeed += 0.25f;
        }
    }
}