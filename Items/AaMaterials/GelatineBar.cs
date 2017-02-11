using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class GelatineBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gelatine Bar";
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 14000;
			item.rare = 1;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GelatineOreItem", 3);
            recipe.AddTile(17);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
			
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GelatineBar", 6);
			recipe.AddIngredient(9, 12);
            recipe.AddTile(16);
            recipe.SetResult(ItemID.SlimeStaff, 1);
            recipe.AddRecipe();
        }
    }
}