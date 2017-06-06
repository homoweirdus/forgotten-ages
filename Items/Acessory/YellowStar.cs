using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class YellowStar : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 10000;
        item.rare = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Yellow Star");
      Tooltip.SetDefault("Increased maximum mana by 20");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statManaMax2 += 20;
	}
}}
