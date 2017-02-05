using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class arknife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 50;
			projectile.height = 50;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 60;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.name = "arknife";
			Main.projFrames[projectile.type] = 28;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20);
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].noGravity = true;
			}
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 1)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			
			if (Main.rand.Next(3) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			}
		}
	}
}