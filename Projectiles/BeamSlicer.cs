using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class BeamSlicer : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Beam Slicer";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 2;
			projectile.penetrate = 2;
			projectile.thrown = true;
			projectile.friendly = true;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0,  60, 0f, 0f);
			}
			if (Main.rand.Next(20) == 0)
			{
				float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
				float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
				int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
				Main.projectile[z].magic = false;
				Main.projectile[z].thrown = true;
			}
		}
	}
}	