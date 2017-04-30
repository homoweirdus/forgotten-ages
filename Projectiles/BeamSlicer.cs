using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class BeamSlicer : ModProjectile
	{
		int counterA = 0;
		int counterB = 0;
		public override void SetDefaults()
		{
			projectile.name = "Beam Slicer";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.timeLeft = 600;
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
			projectile.rotation += 0.2f;
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0,  60, 0f, 0f);
			}
			
			projectile.velocity *= 0.95f;
			projectile.alpha += 5;
			if (projectile.alpha == 255 && counterA == 0)
			{
				int A = Main.rand.Next(-50, 50);
				int B = Main.rand.Next(-50, 50);
				projectile.position.X = projectile.Center.X + A;
				projectile.position.Y = projectile.Center.Y + B;
				counterA++;
				counterB++;
			}
			
			if (counterA >= 1)
			{
				if (counterB <= 3)
				{
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 10, 0, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[z].magic = false;
					Main.projectile[z].penetrate = -1;
					Main.projectile[z].thrown = true;
					Main.projectile[z].tileCollide = false;
					Main.projectile[z].timeLeft = 40;
					int y = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -10, 0, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[y].magic = false;
					Main.projectile[y].penetrate = -1;
					Main.projectile[y].thrown = true;
					Main.projectile[y].tileCollide = false;
					Main.projectile[y].timeLeft = 40;
					int x = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 10, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[x].magic = false;
					Main.projectile[x].thrown = true;
					Main.projectile[x].penetrate = -1;
					Main.projectile[x].tileCollide = false;
					Main.projectile[x].timeLeft = 40;
					int w = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -10, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[w].magic = false;
					Main.projectile[w].thrown = true;
					Main.projectile[w].penetrate = -1;
					Main.projectile[w].tileCollide = false;
					Main.projectile[w].timeLeft = 40;
					int v = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 7, 7, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[v].magic = false;
					Main.projectile[v].thrown = true;
					Main.projectile[v].tileCollide = false;
					Main.projectile[v].penetrate = -1;
					Main.projectile[v].timeLeft = 40;
					int zx = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -7, 7, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[zx].magic = false;
					Main.projectile[zx].thrown = true;
					Main.projectile[zx].penetrate = -1;
					Main.projectile[zx].tileCollide = false;
					Main.projectile[zx].timeLeft = 40;
					int zxx = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 7, -7, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[zxx].magic = false;
					Main.projectile[zxx].penetrate = -1;
					Main.projectile[zxx].thrown = true;
					Main.projectile[zxx].tileCollide = false;
					Main.projectile[zxx].timeLeft = 40;
					int zxxx = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -7, -7, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					Main.projectile[zxxx].magic = false;
					Main.projectile[zxxx].thrown = true;
					Main.projectile[zxxx].penetrate = -1;
					Main.projectile[zxxx].tileCollide = false;
					Main.projectile[zxxx].timeLeft = 40;
				}
				projectile.alpha = 0;
				counterA = 0;
			}
			
			if (counterB >= 3)
			{
				projectile.Kill();
			}
		}
	}
}	