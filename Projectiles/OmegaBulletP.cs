using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class OmegaBulletP : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Omega Bullet";
			projectile.width = 2;
			projectile.height = 100;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 360;
			projectile.penetrate = 1;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 128, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(6) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
			
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
				Vector2 move = Vector2.Zero;
				float distance = 300f;
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
					projectile.velocity = (move * 14f);
				}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int k = 0; k <= 5; k++)
			{
				float dX = 0;
				float dY = 0;
				dX += (float)Main.rand.Next(-60, 61) * 0.4f;
				dY += (float)Main.rand.Next(-60, 61) * 0.4f;
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, dX, dY);
				Main.dust[dust].scale = 0.6f;
				Main.dust[dust].noGravity = true;
			}
			Player player = Main.player[projectile.owner];
			if (target.life <= 1)
			{
				player.HealEffect(projectile.damage/5);
				player.statLife += projectile.damage/5;
				for (int i = 0; i <= 20; i++)
				{
					float sX = 0;
					float sY = 25;
					sX += (float)Main.rand.Next(-30, 30) * 0.5f;
					sY += (float)Main.rand.Next(-10, 30) * 0.5f;
					Projectile.NewProjectile(target.Center.X, (target.Center.Y-1000), sX, sY, projectile.type, projectile.damage, projectile.knockBack, player.whoAmI);
				}
			}
		}		
	}
}