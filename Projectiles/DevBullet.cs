using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DevBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Red Flame";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 1000;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 60, 0f, 0f);
			
			if (Main.rand.Next(2) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("reddust"), 0f, 0f);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			int kek = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("redboom"), (int)(projectile.damage/2), 5f, projectile.owner);
			Main.projectile[kek].melee = false;
			Main.projectile[kek].ranged = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
	}
}