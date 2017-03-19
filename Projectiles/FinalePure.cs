using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class FinalePure : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Finale Bolt";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			int dust2;
			dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].scale = 1.5f;
			Main.dust[dust2].noGravity = true;
			int dust3;
			dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust3].scale = 1.5f;	
			Main.dust[dust3].noGravity = true;
			int dust4;
			dust4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust4].scale = 1.5f;	
			Main.dust[dust4].noGravity = true;
			int dust5;
			dust5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust5].scale = 1.5f;	
			Main.dust[dust5].noGravity = true;
			}
			
			projectile.rotation += 10;
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
				projectile.velocity = (move * 20f);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			int amountOfProjectiles = Main.rand.Next(2, 3);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
				float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("climaxproj"), projectile.damage, 5f, projectile.owner);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(24, 1800, false);
			target.AddBuff(153, 1800, false);
			target.AddBuff(204, 1800, false);
			target.AddBuff(44, 1800, false);
			target.AddBuff(39, 1800, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 1800, false);
			target.AddBuff(mod.BuffType("Gelled"), 1800, false);
		}
	}
}