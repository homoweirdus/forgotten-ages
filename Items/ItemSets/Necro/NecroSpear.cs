using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class NecroSpear : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Bone Lance";
			item.damage = 47;
			item.toolTip = "Impales the impurity.";
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.value = 138000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("NecroSpearP");  //put your Spear projectile name
			item.shootSpeed = 7;

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
