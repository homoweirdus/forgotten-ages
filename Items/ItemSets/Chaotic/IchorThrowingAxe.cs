using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Chaotic
{
	public class IchorAxe : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.name = "Ichor Throwing Axe";
			projectile.width = 30;     
			projectile.height = 32;
			projectile.penetrate = -1;
			aiType = ProjectileID.Shuriken;
			projectile.ignoreWater = true;
			projectile.timeLeft = 6000;
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("IchorThrowingAxe"));
			}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}

		public override void AI()
		{
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 19, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(69, 180, false);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				target.AddBuff(69, 180, false);
			}
		}
	}
	// This .cs file has 2 classes in it, which is totally fine. (What is important is that namespace+classname is unique. Remember that autoloaded textures follow the namespace+classname convention as well.)
	// This is an approach you can take to fit your organization style.
	public class IchorThrowingAxe : ModItem
	{

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.damage = 30;
			item.shoot = mod.ProjectileType("IchorAxe");
			item.name = "Ichor Throwing Axe";
			item.rare = 4;
			item.shootSpeed = 15f;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor, 1);
			recipe.AddTile(16);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
