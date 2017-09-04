using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class StingerShurikenP : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.width = 22;       //projectile width
			projectile.height = 22;
			projectile.penetrate = 3;
			aiType = ProjectileID.Shuriken;
			projectile.ignoreWater = true;
			projectile.timeLeft = 6000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sting Shuriken");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(4) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("StingerShuriken"));
			}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 7);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(20, 180, false);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				target.AddBuff(20, 180, false);
			}
		}
	}

	
	public class StingerShuriken : ModItem
	{

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.shoot = mod.ProjectileType("StingShurikenP");
			item.damage = 18;
			item.rare = 2;
			item.autoReuse = true;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sting Shuriken");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(209, 1);
			recipe.AddTile(16);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}
