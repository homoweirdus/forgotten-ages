using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Info
{
    public class Info : ProjectileInfo
    {
		public bool Paradox = false;
		public bool Mutilator = false;
		public bool TrueHR = false;
		public bool Shroom = false;
    }
	
	public class Stuff : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0 && projectile.GetModInfo<Info>(mod).Paradox == true)
			{
			int z = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X * 100f, projectile.Center.Y + projectile.velocity.Y * 100f, projectile.velocity.X * -1, projectile.velocity.Y * -1, projectile.type, projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.projectile[z].GetModInfo<Info>(mod).Paradox = true;
			Main.projectile[z].tileCollide = false;
			Main.projectile[z].penetrate = 1;
			}
			if(Main.rand.Next(3) == 0 && projectile.GetModInfo<Info>(mod).Mutilator == true)
			{
            target.AddBuff(69, 360);
			}
		}
		
		public override void Kill(Projectile projectile, int timeLeft)
		{
			if (projectile.GetModInfo<Info>(mod).TrueHR == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 4);
			
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
						float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
						Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("HallowEnergy"), 20, 5f, projectile.owner);
					}
			}
		}
		
		public override void AI(Projectile projectile)
		{
			if (projectile.GetModInfo<Info>(mod).TrueHR == true)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("bluedust"), 0f, 0f);
				Main.dust[dust].scale = 0.9f;
				Main.dust[dust].noGravity = true;
				int hitler;
				hitler = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("pinkdust"), 0f, 0f);
				Main.dust[hitler].scale = 0.9f;
				Main.dust[hitler].noGravity = true;
			}
			
			if (projectile.GetModInfo<Info>(mod).Shroom == true)
			{
				Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
				Vector2 move = Vector2.Zero;
				float distance = 150f;
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
		}
	}
}
