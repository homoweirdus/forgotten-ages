using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class NecroflameChainsaw : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Necroflame Chainsaw";
			item.damage = 9;
			item.melee = true;
			item.width = 24;
			item.height = 8;
			item.useTime = 7;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.axe = 21;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 138000;
			item.rare = 4;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecroflameChainsawProj");
			item.shootSpeed = 40f;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NecroBar", 12);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}