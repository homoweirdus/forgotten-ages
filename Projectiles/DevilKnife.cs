using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DevilKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 2;
			//projectile.timeLeft = 1000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devil Knife");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.Center.X, (int)projectile.Center.Y, projectile.width, projectile.height, mod.ItemType("DevilKnife"));
        	}
			
			if (Main.rand.Next(2) == 0)
        	{
				Vector2 vector2 = (projectile.velocity / 2).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
        		Projectile.NewProjectile((float) projectile.Center.X, (float) projectile.Center.Y, vector2.X, vector2.Y, mod.ProjectileType("LivingFlame"), (int) ((double) projectile.damage * 0.75), projectile.knockBack, projectile.owner, 0.0f, 0.0f);
        	}
			
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 7);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 360, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
		
		public override void AI()
		{
			if (projectile.velocity.X >= 0)
			{
				projectile.velocity.X -= 0.15f;
			}
			if (projectile.velocity.X <= 0)
			{
				projectile.velocity.X += 0.15f;
			}
			if (projectile.velocity.X == 0)
			{
				projectile.velocity.X -= 0f;
			}
			projectile.velocity.Y += 0.15f;
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 6, 0f, 0f);
			}
		}
	}
}