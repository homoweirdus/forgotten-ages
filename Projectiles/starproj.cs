using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
public class starproj : ModProjectile
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
	}
	
	public override void Kill(int timeLeft)
    {
		for (int i = 0; i < 10; i++)
		{
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
        }
    }
}
}	