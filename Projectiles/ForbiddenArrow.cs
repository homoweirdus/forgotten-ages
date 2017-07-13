using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ForbiddenArrow : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 1000;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Arrow");
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			projectile.position.X += (float) (projectile.width / 4);
			projectile.position.Y += (float) (projectile.height / 4);
			projectile.width = (int) (64.0 * (double) projectile.scale);
			projectile.height = (int) (64.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 4);
			projectile.position.Y -= (float) (projectile.height / 4);
			for (int index1 = 0; index1 < 8; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 8; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			}
			if (projectile.owner == Main.myPlayer)
			{
			  projectile.localAI[1] = -1f;
			  projectile.maxPenetrate = 0;
			  projectile.Damage();
			}
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 32, 0f, 0f);
			}
			timer++;
			if (timer >= 15)
			{
				projectile.tileCollide = true;
			}
		}
	}
}