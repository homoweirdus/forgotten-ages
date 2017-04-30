using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	public class TitanRock : ModNPC
	{
		int timer = 0;
		int timer2 = 2;
		int timer3 = 0;
		int falltimer = 0;
		bool bisexual = false;
		bool bisexual2 = false;
		bool despawn = false;
		bool spawnedMiniTitans1 = false;
		bool spawnedMiniTitans2 = false;
		Vector2 gayvector = new Vector2(0f, -5f);
		Vector2 homovector = new Vector2(0f, 5f);
		
		public override void SetDefaults()
		{
			npc.name = "Titan Rock";
			npc.displayName = "Titan Rock";
			npc.aiStyle = -1;
			npc.lifeMax = 11000;
			npc.damage = 60;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.width = 100;
			npc.height = 100;
			npc.value = Item.buyPrice(0, 2, 0, 0);
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			Main.npcFrameCount[npc.type] = 4;
			npc.scale = 1.25f;
			npc.npcSlots = 5;
			music = MusicID.Boss3;
		}
		
		public override void AutoloadHead(ref string headTexture, ref string bossHeadTexture)
		{
			bossHeadTexture = "ForgottenMemories/NPCs/TitanRock/TitanRock_Head_Boss";
		}
		
		public override void BossHeadRotation (ref float rotation)
		{
			rotation = npc.rotation;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
			{
				npc.lifeMax = 15000 + ((numPlayers) * 4000);
				npc.damage = 70;
				npc.defense = 20;
			}

		public override void ModifyHitByProjectile (Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && Main.npc[k].type == mod.NPCType("MiniTitan"))
					{
						damage = 0;
					}
				}
		}
		
		public override void ModifyHitByItem (Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && Main.npc[k].type == mod.NPCType("MiniTitan"))
					{
						damage = 0;
					}
				}
		}
		
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			timer++;
			
			if (npc.life <= (int)(npc.lifeMax/2) && despawn == false)
			{		
				if (spawnedMiniTitans1 == false)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					spawnedMiniTitans1 = true;
				}
				
				if (spawnedMiniTitans2 == false && Main.expertMode && npc.life <= (int)(npc.lifeMax/4))
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					spawnedMiniTitans2 = true;
				}
				npc.rotation += 0.20f;
				npc.ai[2] += 1f;
				if (npc.ai[2] >= 800f)
				{
					npc.ai[2] = 0f;
					npc.ai[1] = 1f;
					npc.TargetClosest(true);
					npc.netUpdate = true;
				}
				npc.velocity.X = 0;
				if (falltimer == 0)
				{
					float A = Main.rand.Next(-250, 250) * 1.2f;
					npc.position.X = player.Center.X + A;
					npc.position.Y = player.Center.Y - 500;
					
					float REE = 0;
					if (Main.rand.Next (2) == 1)
					{
						REE = 1;
					}
					
					else
					{
						REE = -1;
					}
					Vector2 ogVect = new Vector2 ((Main.rand.Next(-4, -1)*REE), (Main.rand.Next(-4, 1)*REE));
					Vector2 ogVect2 = ogVect.RotatedBy(System.Math.PI / 4);
					Vector2 ogVect3 = ogVect.RotatedBy(System.Math.PI / 2);
					Vector2 ogVect4 = ogVect.RotatedBy((3 * System.Math.PI) / 4);
					Vector2 ogVect5 = ogVect.RotatedBy(System.Math.PI);
					Vector2 ogVect6 = ogVect.RotatedBy((5 * System.Math.PI) / 4);
					Vector2 ogVect7 = ogVect.RotatedBy((3 * System.Math.PI) / 2);
					Vector2 ogVect8 = ogVect.RotatedBy((7 * System.Math.PI) / 4);
					
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect.X, ogVect.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect2.X, ogVect2.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect3.X, ogVect3.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect4.X, ogVect4.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect5.X, ogVect5.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect6.X, ogVect6.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect7.X, ogVect7.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect8.X, ogVect8.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					
					for (int m = 0; m <= 20; m++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					}
					falltimer += 1;
				}
				
				if (falltimer >= 0)
				{
					npc.velocity.Y = 8;
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					falltimer++;
				}
				
				if (npc.position.X > player.position.X)
				{
					npc.velocity.X = -2.2f;
				}
				
				if (npc.position.X < player.position.X)
				{
					npc.velocity.X = 2.2f;
				}
				
				if (falltimer >= 65)
				{
					falltimer = 0;
					
					float REE = 0;
					if (Main.rand.Next (2) == 1)
					{
						REE = 1;
					}
					
					else
					{
						REE = -1;
					}
					Vector2 ogVect = new Vector2 ((Main.rand.Next(-4, -1)*REE), (Main.rand.Next(-4, 1)*REE));
					Vector2 ogVect2 = ogVect.RotatedBy(System.Math.PI / 4);
					Vector2 ogVect3 = ogVect.RotatedBy(System.Math.PI / 2);
					Vector2 ogVect4 = ogVect.RotatedBy((3 * System.Math.PI) / 4);
					Vector2 ogVect5 = ogVect.RotatedBy(System.Math.PI);
					Vector2 ogVect6 = ogVect.RotatedBy((5 * System.Math.PI) / 4);
					Vector2 ogVect7 = ogVect.RotatedBy((3 * System.Math.PI) / 2);
					Vector2 ogVect8 = ogVect.RotatedBy((7 * System.Math.PI) / 4);
					
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect.X, ogVect.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect2.X, ogVect2.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect3.X, ogVect3.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect4.X, ogVect4.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect5.X, ogVect5.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect6.X, ogVect6.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect7.X, ogVect7.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, ogVect8.X, ogVect8.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
					
					for (int r = 0; r <= 20; r++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					}
				}
				
				if (Main.rand.Next(800) == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TitanBat"));
				}
			}
				
			else
			{
				if (timer <= 350)
				{
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 800f)
					{
						npc.ai[2] = 0f;
						npc.ai[1] = 1f;
						npc.TargetClosest(true);
						npc.netUpdate = true;
					}
					npc.rotation = npc.velocity.X / 15f;
					float num586 = 0.02f;
					float num587 = 2f;
					float num588 = 0.05f;
					float num589 = 8f;
					if (Main.expertMode)
					{
						num586 = 0.03f;
						num587 = 4f;
						num588 = 0.07f;
						num589 = 9.5f;
					}
					if (npc.position.Y > Main.player[npc.target].position.Y - 250f)
					{
						if (npc.velocity.Y > 0f)
						{
							npc.velocity.Y = npc.velocity.Y * 0.98f;
						}
						npc.velocity.Y = npc.velocity.Y - num586;
						if (npc.velocity.Y > num587)
						{
							npc.velocity.Y = num587;
						}
					}
					else if (npc.position.Y < Main.player[npc.target].position.Y - 250f)
					{
						if (npc.velocity.Y < 0f)
						{
							npc.velocity.Y = npc.velocity.Y * 0.98f;
						}
						npc.velocity.Y = npc.velocity.Y + num586;
						if (npc.velocity.Y < -num587)
						{
							npc.velocity.Y = -num587;
						}
					}
					if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.98f;
						}
						npc.velocity.X = npc.velocity.X - num588;
						if (npc.velocity.X > num589)
						{
							npc.velocity.X = num589;
						}
					}
					if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.98f;
						}
						npc.velocity.X = npc.velocity.X + num588;
						if (npc.velocity.X < -num589)
						{
							npc.velocity.X = -num589;
						}
					}
					
					if (Main.rand.Next(800) == 0)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TitanBat"));
					}
					
					if (timer == 100 || timer == 200)
					{	
						for (int i = 0; i < 6; ++i)
						{
							Vector2 direction = Main.player[npc.target].Center - npc.Center;
							direction.Normalize();
							float sX = direction.X * 8f;
							float sY = direction.Y * 8f;
							sX += (float)Main.rand.Next(-15, 15) * 0.1f;
							sY += (float)Main.rand.Next(-15, 15) * 0.1f;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball"), 25, 1, Main.myPlayer, 0, 0);
						}
					}
					if (timer == 50 || timer == 150 || timer == 250)
					{	
						if (npc.life <= 10000 && Main.expertMode)
						{
							for (int i = 0; i < 3; ++i)
							{
								Vector2 direction = Main.player[npc.target].Center - npc.Center;
								direction.Normalize();
								float sX = direction.X * 8f;
								float sY = direction.Y * 8f;
								sX += (float)Main.rand.Next(-15, 15) * 0.1f;
								sY += (float)Main.rand.Next(-15, 15) * 0.1f;
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball"), 30, 1, Main.myPlayer, 0, 0);
							}
						}
					}
				}
				
				
				if (timer >= 350)
				{
					if (timer == 300)
					{
						gayvector = new Vector2(0f, -5f);
						homovector = new Vector2(0f, 5f);
					}
					
					timer2++;
					
					npc.rotation += 0.20f;
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					
					if (timer2 >= 5)
					{
						Vector2 newVect = gayvector.RotatedBy(System.Math.PI / 35);
						Vector2 newVect2 = homovector.RotatedBy(System.Math.PI / 35);
						
						if (npc.life <= 1000 && Main.expertMode)
						{
							newVect = gayvector.RotatedBy(System.Math.PI / 27);
							newVect2 = homovector.RotatedBy(System.Math.PI / 27);
						}
						gayvector = newVect;
						homovector = newVect2;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, gayvector.X * 1.5f, gayvector.Y * 1.5f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, homovector.X * 1.5f, homovector.Y * 1.5f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						timer2 = 0;
						
					}
				}
				
				timer3++;
				if (Main.expertMode && timer3 == 600)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
				}
				
				if (npc.life <= 8000 && bisexual2 == false)
				{
					int ok = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
					Main.npc[ok].lifeMax = 800;
					bisexual2 = true;
				}
				
				if (timer >= 650)
				{
					timer = 0;
				}
			}
				
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = -20;
				timer = 0;
				despawn = true;
			}
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.1f; 
			if (npc.life <= 1000 && Main.expertMode)
			{
				npc.frameCounter += 0.1f;
			}
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("TitanRockBag")));
			}
			else
			{
				int amountToDrop = Main.rand.Next(5,10);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProtectionCrystal"), amountToDrop);
				
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserbladeKatana"), 1);
				}
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Needler"), 1);
				}
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserbeamStaff"), 1);
				}
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BeamSlicer"), 1);
				}
			}
			TGEMWorld.downedTitanRock = true;
		}
	}
}
