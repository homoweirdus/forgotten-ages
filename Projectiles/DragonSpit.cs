using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DragonSpit : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Dragon Spit";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 1000;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 6, 0f, 0f);
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("dragonboom"), projectile.damage, 5f, projectile.owner);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(69, 30, false);
			target.AddBuff(203, 30, false);
			target.AddBuff(189, 30, false);
			target.AddBuff(24, 30, false);
			target.AddBuff(mod.BuffType("DragonInferno"), 30, false);
		}
	}
}