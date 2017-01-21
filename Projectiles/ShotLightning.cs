using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
    public class ShotLightning : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Lightning";
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 70;
            projectile.extraUpdates = 4;
			projectile.alpha = 255;
        }
		
		   public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 59, 0f, 0f);
			Main.dust[dust].scale = 1.8f;
			Main.dust[dust].noGravity = true;
			
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
            Vector2 move = Vector2.Zero;
            float distance = 200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
						newMove.Normalize();
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                projectile.velocity = (move * 10f);
				if (Main.rand.Next(5) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 5);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(5) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -5);
				projectile.velocity = newVect2;
			}
            }
			
			if (Main.rand.Next(30) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 5);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(30) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -5);
				projectile.velocity = newVect2;
			}			
			
			
		}
    }
}