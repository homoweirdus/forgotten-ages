using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class ForboodenSlush : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.tileCollide = false;
			projectile.timeLeft = 50;
			projectile.light = 0.5f;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Wave");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 32, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(5) == 0)
			{
				int dust2;
				dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int index1 = 0; index1 < 4; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 4; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			}
		}
	}
}