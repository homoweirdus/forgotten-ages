using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class Hadron : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 120;
			item.ranged = true;
			item.width = 200;
			item.height = 58;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 1400000;
			item.rare = 10;
			//item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Bullet;
			item.shoot = mod.ProjectileType("Hadron");
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.channel = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Hadron");
		  Tooltip.SetDefault("Fires a spread of bullets and void missiles \nIncreases in firing speed, velocity, and damage over time \n'Infused with lunar and dark energies'");
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OnyxBlaster, 1);
			recipe.AddIngredient(ItemID.VortexBeater, 1);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
