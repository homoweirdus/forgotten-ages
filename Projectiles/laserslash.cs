using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class laserslash : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Needle";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.timeLeft = 45;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.melee = true;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			
			projectile.scale += 0.03f;
		}
		
	}
}