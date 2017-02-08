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
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 60;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.name = "arknife";
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
			if (Main.rand.Next(3) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			int dust2;
			dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].noGravity = true;
			}
		}
	}
}