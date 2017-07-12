using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class DevilTrident : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 288;
			item.magic = true;
			item.mana = 25;
			item.width = 29;
			item.height = 30;
			item.useTime = 38;
			item.UseSound = SoundID.Item45;

			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 650000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DevilTrident");
			item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Devil's Trident");
		  Tooltip.SetDefault("Casts a demonic pitchfork that explodes into an inferno");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.InfernoFork, 1);
			recipe.AddIngredient(ItemID.UnholyTrident, 1);
			recipe.AddIngredient(null,"CosmodiumBar", 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
