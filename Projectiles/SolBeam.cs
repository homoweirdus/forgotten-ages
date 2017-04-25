using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class SolBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Solar Beam";
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.light = 0.5f;
			projectile.alpha = 0;
			projectile.timeLeft = 100;
			Main.projFrames[projectile.type] = 4;
			projectile.scale = 1f;
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			projectile.velocity *= 0.95f;
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 244, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i <= 4; i++)
			{
				float cX = projectile.Center.X;
				float cY = projectile.Center.Y;
				cX += Main.rand.Next(-60, 60);
				cY += Main.rand.Next(-60, 60);
				int kk = Projectile.NewProjectile(cX, cY, 0f, 0f, mod.ProjectileType("solarboom"), projectile.damage, 5f, projectile.owner);
				Main.projectile[kk].melee = false;
				Main.projectile[kk].magic = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int i = 0; i <= 8; i++)
			{
				float cX = projectile.Center.X;
				float cY = projectile.Center.Y;
				cX += Main.rand.Next(-70, 70);
				cY += Main.rand.Next(-70, 70);
				int kk = Projectile.NewProjectile(cX, cY, 0f, 0f, mod.ProjectileType("solarboom"), projectile.damage, 5f, projectile.owner);
				Main.projectile[kk].melee = false;
				Main.projectile[kk].magic = true;
			}
		}
	}
}