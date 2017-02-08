using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles 
{
	public class BloodBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Blood Execution";
			projectile.width = 50;
			projectile.height = 50;
			projectile.aiStyle = -1;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;			
			}
		}
	}
}	