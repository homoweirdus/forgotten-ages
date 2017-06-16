using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss {
public class ForestPortal : ModProjectile
{
	int timer = 0;
	public override void SetDefaults()
	{
		projectile.width = 32;
		projectile.height = 32;
		projectile.aiStyle = 0;
		projectile.penetrate = 5;
		projectile.hostile = true;
        projectile.friendly = false;
		projectile.scale = 1.1f;
		projectile.tileCollide = false;
		projectile.timeLeft = 500;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forest Portal");
		Main.projFrames[projectile.type] = 4;
		}
	
			public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
			
			if (Main.rand.Next(10) == 0)
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 34, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}
		timer++;
		
		if (timer == 35)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, -2f, mod.ProjectileType("GreenApple"), projectile.damage, 5f, projectile.owner);
		}
		if (timer == 70)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, -2f, mod.ProjectileType("RedApple"), projectile.damage, 5f, projectile.owner);
			timer = 0;
		}
		}
}
}	