using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class meleestorm : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 30;
			projectile.light = 0.5f;
			projectile.extraUpdates = 30;
			aiType = ProjectileID.Bullet;
			projectile.name = "meleestorm";
		}
		

		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1.5f;
			}
		}
	}
}