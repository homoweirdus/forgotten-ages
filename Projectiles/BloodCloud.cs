using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BloodCloud : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.name = "Blood Cloud";
			projectile.width = 32;
			projectile.height = 24;
			projectile.aiStyle = 0;
			projectile.penetrate = 5;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.scale = 1.1f;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 6;
			projectile.timeLeft = 300;
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			
			if (Main.rand.Next(10) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 34, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			timer++;
			
			if (timer == 50)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 10f, 280, projectile.damage, 5f, projectile.owner);
				timer = 0;
			}
		}
	}
}	