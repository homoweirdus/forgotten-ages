using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ChainLightning2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Lightning";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 35;
			projectile.extraUpdates = 4;
			projectile.alpha = 255;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 226, 0f, 0f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			if (Main.rand.Next(30) == 0)
			{
				if (Main.rand.Next(3) == 0)
				{
					Vector2 coolVect = projectile.velocity.RotatedBy(System.Math.PI / -5);
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, coolVect.X, coolVect.Y, mod.ProjectileType("PistolLightning2"), projectile.damage, 5f, projectile.owner);
				}
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 5);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(30) == 0)
			{
				if (Main.rand.Next(3) == 0)
				{
					Vector2 coolVect = projectile.velocity.RotatedBy(System.Math.PI / 5);
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, coolVect.X, coolVect.Y, mod.ProjectileType("PistolLightning2"), projectile.damage, 5f, projectile.owner);
				}
				
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -5);
				projectile.velocity = newVect2;
			}			
			
			
		}
	}
}