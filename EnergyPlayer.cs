using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
	public class EnergyPlayer : ModPlayer
	{
		public bool treeMinion = true;
        public bool lifesteal = false;
		public bool firestorm = false;
		public bool doubleJumpMeteor = false;
		public bool meteor = false;
		public bool hadron = false;
		public bool dJumpEffectMeteor = false;
		public bool sapBall = false;
		public bool canJumpFirestorm = true;
		public bool SlimyNeck = true;
		public bool jungard = true;
		
			public override void ResetEffects()
		{
			firestorm = false;
			doubleJumpMeteor = false;
			hadron = false;
			treeMinion = false;
            lifesteal = false;
			sapBall = false;
			SlimyNeck = false;
			jungard = false;
		}
		

            public override void OnHitAnything(float x, float y, Entity victim)
            {
                if (Main.rand.Next(8) == 0 && lifesteal == true)
                {
                    player.HealEffect(1);
                    player.statLife += 1;
                }
            }
			
			public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
			{
				if (sapBall == true && Main.rand.Next(3) == 0)
				{
					if (projectile.minion == true || ProjectileID.Sets.MinionShot[projectile.type] || ProjectileID.Sets.SentryShot[projectile.type])
					{
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SapSphere"), projectile.damage, 5f, player.whoAmI);
					}
				}
				
				if (SlimyNeck == true && Main.rand.Next(7) == 0)
				{
					if (projectile.minion == true || ProjectileID.Sets.MinionShot[projectile.type] || ProjectileID.Sets.SentryShot[projectile.type])
					{
						target.AddBuff(mod.BuffType("Gelled"), 60, false);
					}
				}
			}
			
			public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
			{
				if (jungard == true)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("JungleGuard"), 15, 5f, player.whoAmI);
				}
			}
			
			public override void PreUpdate()
			{
				
				if(player.controlJump)
				{
					if(!player.mount.Active && canJumpFirestorm == true && firestorm == true)
					{
						if(player.controlLeft)
						{
							player.velocity.X = -10f;
						}
						if(player.controlRight)
						{
							player.velocity.X = 10f;
						}
						Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 34);
											
						int amountOfProjectiles = Main.rand.Next(5, 10);
									
						for (int i = 0; i < amountOfProjectiles; ++i)
						{
							float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
							float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
							int projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, 400, 15, 5f, player.whoAmI);
							Main.projectile[projectile].timeLeft = 100;
						}				
						canJumpFirestorm = false;
					}

					bool flag = false;
					if (flag = false && meteor == true)
					{
						flag = true;
						meteor = false;
					}

					if (player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped))
					{
						if (doubleJumpMeteor == true)
						{
							meteor = true; //refreshes the meteor jump
						}	
					}						

					else if (flag == true) 
					{
						dJumpEffectMeteor = true;
						player.jump = Player.jumpHeight * 2;
						Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 34);
					}
				}
					
				if (player.justJumped == true)
				{
					canJumpFirestorm = true;
				}	
			}
			
			public void DoubleJumpVisuals()
			{
				if (dJumpEffectMeteor == true && doubleJumpMeteor == true && meteor == false && !player.jumpAgainCloud && (!player.jumpAgainSandstorm || !player.doubleJumpSandstorm) && ((player.gravDir == 1f && player.velocity.Y < 0f) || (player.gravDir == -1f && player.velocity.Y > 0f)))
				{
					int kys = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 3, 424, 15, 5f, player.whoAmI);
					Main.projectile[kys].magic = false; //creates meteors
				}
			}
		}
	}