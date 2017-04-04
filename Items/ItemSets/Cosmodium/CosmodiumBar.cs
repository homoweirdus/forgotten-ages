using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumBar : ModItem
	{
		public override void SetDefaults()
		{	
            item.name = "Cosmodium Bar";
            item.width = 24;
            item.height = 28;
            item.value = 50000;
            item.rare = 11;
            item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumOre", 4);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
