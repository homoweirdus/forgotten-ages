using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class gelstream : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 35;
			projectile.height = 35;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 70;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gel Stream");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft <= 62)
			{
				if (Main.rand.Next(4) == 0)
				{
					int dust;
					dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("geldust"), 0f, 0f);
					Main.dust[dust].scale = 1f;
				}
				if (Main.rand.Next(14) == 0  && projectile.timeLeft >= 10)
				{
					int dust;
					dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("geldust"), 0f, 0f);
					Main.dust[dust].scale = 1.5f;
				}
				if (Main.rand.Next(18) == 0 && projectile.timeLeft >= 25)
				{
					int dust;
					dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("geldust"), 0f, 0f);
					Main.dust[dust].scale = 1.7f;
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Gelled"), 60, false);
		}
	}
}