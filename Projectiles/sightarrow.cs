using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class sightarrow : ModProjectile
    {
		int counter = 0;
        public override void SetDefaults()
        {
            projectile.width = 10;
			projectile.height = 30;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
			projectile.alpha = 50;
			projectile.scale = 1.3f;
			projectile.timeLeft = 1000;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arrow of Sight");
		}
		
		   public override void AI()
		{
			Player player = Main.player[projectile.owner];
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.8f;	
			Main.dust[dust].noGravity = true;		
			if (Main.mouseRight)
			{
				Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
				Vector2 move = Vector2.Zero;
				float distance = 400f;
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
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 15f, move.Y * 15f, mod.ProjectileType("SightBeam"), (int)(projectile.damage * 0.80), 5f, projectile.owner);
					projectile.Kill();
				}
			}
		}
		
		public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
    }
}