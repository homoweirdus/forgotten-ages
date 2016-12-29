using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
public class pinkstar : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Pixie Star";
		projectile.width = 50;
		projectile.height = 50;
		projectile.aiStyle = 0;
		projectile.penetrate = 5;
		projectile.melee = true;
		projectile.friendly = true;
		projectile.alpha = 100;
		projectile.timeLeft = 200;
		projectile.tileCollide = false;
		projectile.light = 0.5f;
	}
	
	public override void Kill(int timeLeft)
    {
		for (int i = 0; i < 10; i++)
		{
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
        }
    }
	
	public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
}
}	