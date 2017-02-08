using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Acessory
{
    public class PaladinEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Paladin Emblem";
            item.width = 28;
            item.height = 28;
            item.toolTip = "Reduces damage taken by 12%";
            item.value = 100000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.12f;
        }
    }
}