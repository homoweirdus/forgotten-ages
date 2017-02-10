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
			projectile.name = "Gel Stream";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("geldust"), 0f, 0f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Gelled"), 60, false);
		}
	}
}