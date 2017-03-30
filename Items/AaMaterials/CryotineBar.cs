using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class CryotineBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cryotine Bar";
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 14000;
			item.rare = 1;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryotineOreItem", 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
						
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(null,"CryotineBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(987, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 7);
			recipe.AddIngredient(null,"CryotineBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(950, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 7);
			recipe.AddIngredient(null,"CryotineBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(1579, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Frostbrand, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlowerofFire, 1);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddIngredient(null,"CryotineBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.FlowerofFrost, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddIngredient(null,"CryotineBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.IceBow, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Frostbrand, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlowerofFire, 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddIngredient(null,"CryotineBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.FlowerofFrost, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddIngredient(null,"CryotineBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.IceBow, 1);
            recipe.AddRecipe();
        }
    }
}