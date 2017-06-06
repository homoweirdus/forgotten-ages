using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumOre : ModItem
	{
		public override void SetDefaults()
		{	

            item.width = 24;
            item.height = 28;
            item.value = 10000;
            item.rare = 11;

            item.maxStack = 999;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("Cosmodium");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmodium Ore");
      Tooltip.SetDefault("'Pulsing with energy from another realm'");
    }


		
	}
}
