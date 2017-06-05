using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class icearrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Ice Arrow";
			projectile.width = 10;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 6;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 1000;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 67, 0f, 0f);
				Main.dust[dust].scale = 0.5f;
			}
			
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 59, 0f, 0f);
				Main.dust[dust2].scale = 0.5f;
			}
		}
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) < 2)
			{
				target.AddBuff(BuffID.Frostburn, 60, false);
			}
			if (Main.rand.Next(100) < 99)
			{
				target.AddBuff(mod.BuffType("Frozen"), 10, false);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}