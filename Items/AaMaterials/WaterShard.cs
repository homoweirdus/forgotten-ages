using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class WaterShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 6000;
			item.rare = 2;
			item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Water Shard");
      Tooltip.SetDefault("");
    }

		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 7);
            recipe.AddTile(16);
            recipe.SetResult(164, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 15);
			recipe.AddIngredient(ItemID.Bone, 19);
            recipe.AddTile(16);
            recipe.SetResult(157, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 12);
			recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddTile(16);
            recipe.SetResult(113, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 15);
            recipe.AddTile(16);
            recipe.SetResult(163, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 18);
            recipe.AddTile(16);
            recipe.SetResult(156, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 13);
            recipe.AddTile(16);
            recipe.SetResult(155, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 17);
			recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(16);
            recipe.SetResult(null, "YoichiBow", 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 6);
			recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddTile(16);
            recipe.SetResult(3317, 1);
            recipe.AddRecipe();
        }
	}
}
