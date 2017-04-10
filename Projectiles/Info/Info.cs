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
		public bool Cosmodium = false;
		public bool Shroom = false;
		public bool Flamethrower = false;
		public bool Terra = false;
		public bool Titanium = false;
		public bool Planetary = false;
		public bool Split = false;
		public bool wtf = false;
	}
	
	public class Stuff : GlobalProjectile
	{
		
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.GetModInfo<Info>(mod).Flamethrower == true)
			{
				target.immune[projectile.owner] = 5;
			}
			
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
			if (Main.rand.Next(2) == 0 && projectile.GetModInfo<Info>(mod).Planetary == true)
			{
				Player player = Main.player[projectile.owner];
				Vector2 newMove = projectile.Center - player.Center;
				float memes = newMove.X * 15f;
				float memes2 = newMove.Y * 15f;
				memes += (float)Main.rand.Next(-40, 41) * 0.1f;
				memes2 += (float)Main.rand.Next(-40, 41) * 0.1f;
				int z = Projectile.NewProjectile(player.Center.X, player.Center.Y, memes, memes2, projectile.type, projectile.damage, 0f, projectile.owner, 0f, 0f);
				if(Main.rand.Next(3) == 0)
				{
					Main.projectile[z].GetModInfo<Info>(mod).Planetary = true;
				}
			}
		}
		
		public override void Kill(Projectile projectile, int timeLeft)
		{
			if (projectile.GetModInfo<Info>(mod).TrueHR == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 3);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("HallowEnergy"), 20, 5f, projectile.owner);
					
				}
			}
			
			if (projectile.GetModInfo<Info>(mod).Split == true && projectile.timeLeft == 0)
			{
				Vector2 origVect = new Vector2(projectile.velocity.X, projectile.velocity.Y);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 30);
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / 30);
				Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / 60);
				Vector2 newVect5 = origVect.RotatedBy(System.Math.PI / 60);
				int ok1 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, origVect.X, origVect.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok2 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect2.X, newVect2.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok3 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect3.X, newVect3.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok4 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect4.X, newVect4.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok5 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect5.X, newVect5.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				Main.projectile[ok1].GetModInfo<Info>(mod).wtf = true;
				Main.projectile[ok2].GetModInfo<Info>(mod).wtf = true;
				Main.projectile[ok3].GetModInfo<Info>(mod).wtf = true;
				Main.projectile[ok4].GetModInfo<Info>(mod).wtf = true;
				Main.projectile[ok5].GetModInfo<Info>(mod).wtf = true;
			}
			
			if (projectile.GetModInfo<Info>(mod).Cosmodium == true)
			{
				int amountOfProjectiles = Main.rand.Next(2, 4);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					int B = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("CosmodiumBolt2"), projectile.damage, 5f, projectile.owner);
					Main.projectile[B].magic = false;
					Main.projectile[B].ranged = true;
				}
			}
			
			if (projectile.GetModInfo<Info>(mod).Titanium == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 4);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 126, 15, 5f, projectile.owner);
				}
			}
			
			if (projectile.GetModInfo<Info>(mod).Terra == true)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("TerraBoom"), 30, 5f, projectile.owner);
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
			
			if (projectile.GetModInfo<Info>(mod).Terra == true)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 74, 0f, 0f);
				Main.dust[dust].scale = 0.9f;
				Main.dust[dust].noGravity = true;
			}
			
			if (projectile.GetModInfo<Info>(mod).wtf == true && projectile.velocity.X == 0 && projectile.velocity.Y == 0)
			{
				projectile.Kill();
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
