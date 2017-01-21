using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class OblivionWave : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Oblivion Wave";
			projectile.width = 80;
			projectile.height = 48;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 3;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		
		}
	}