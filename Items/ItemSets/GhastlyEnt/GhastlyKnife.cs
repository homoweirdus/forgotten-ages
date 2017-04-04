using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class GhastlyKnife : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 15;
			item.thrown = true;
			item.shoot = mod.ProjectileType("GhastlyKnife");
			item.name = "Ghastly Knife";
			item.consumable = true;
			item.shootSpeed = 10f;
			item.useTime = 17;
			item.useAnimation = 17;
			item.toolTip = "Splits into woodchips when destroyed";
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 38;
			item.rare = 2;
			item.shootSpeed = 15f;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}