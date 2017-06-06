using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class DevilKnife : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 13;
			item.thrown = true;
			item.shoot = mod.ProjectileType("DevilKnife");

			item.consumable = true;
			item.shootSpeed = 11f;
			item.useTime = 17;
			item.useAnimation = 17;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 22;
			item.rare = 2;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Devil Knife");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DevilFlame", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 45);
			recipe.AddRecipe();
		}
	}
}
