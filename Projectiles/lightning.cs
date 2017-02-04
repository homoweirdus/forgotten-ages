using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class lightning : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Doom Lightning";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 100;
			projectile.extraUpdates = 100;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 65, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			
			
			if (Main.rand.Next(10) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 10);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(10) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -10);
				projectile.velocity = newVect2;
			}			
			
			
		}
	}
}