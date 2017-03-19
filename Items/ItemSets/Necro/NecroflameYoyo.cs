using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro 
{
	public class NecroflameYoyo : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Graverobber";
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 25;
			item.useTime = 25;
			item.toolTip = "Fires shadowflame skulls at nearby enemies";
			item.shootSpeed = 16f;
			item.knockBack = 3.75f;
			item.damage = 39;
			item.value = 138000;
			item.rare = 4;
			item.maxStack = 1;
			item.shoot = mod.ProjectileType("NecroflameYoyo");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NecroBar", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}