using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class improj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "improj";
			projectile.width = 39;
			projectile.height = 124;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 400;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.height, projectile.width, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(4) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.height, projectile.width, 14, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(5) == 0)
			{
				projectile.velocity.Y *= 0.9f;
				projectile.velocity.X *= 0.9f;
			}
			if (Main.rand.Next(5) == 0)
			{
				projectile.velocity.Y *= 1.1f;
				projectile.velocity.X *= 1.1f;
			}
			if (Main.rand.Next(10) == 0)
			{
				projectile.velocity.Y *= 1.1f;
				projectile.velocity.X *= 0.9f;
			}
			if (Main.rand.Next(10) == 0)
			{
				projectile.velocity.Y *= 0.9f;
				projectile.velocity.X *= 1.1f;
			}
		}
	}
}