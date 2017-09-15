using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	[AutoloadBossHead]
	public class TitanRock : ModNPC
	{
		int timer = 0;
		int timer2 = 2;
		int timer3 = 0;
		int falltimer = 0;
		bool bisexual = false;
		bool bisexual2 = false;
		float teleportF;
		bool despawn = false;
		bool phase2transition = false;
		bool canTPAgain = false;
		bool OnScreen = false;
		bool spawnedMiniTitans1 = false;
		bool spawnedMiniTitans2 = false;
		int transgender = 0;
		Vector2 gayvector = new Vector2(0f, -5f);
		Vector2 homovector = new Vector2(0f, 5f);
		Vector2 lesvector = new Vector2(-5f, 0f);
		Vector2 bivector = new Vector2(5f, 0f);
		
		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 28000;
			npc.damage = 60;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.width = 170;
			npc.height = 170;
			npc.value = Item.buyPrice(0, 12, 0, 0);
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.scale = 1.25f;
			npc.npcSlots = 5;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/TitanRock");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Rock");
			Main.npcFrameCount[npc.type] = 6;
		}
		
		public override void BossHeadRotation (ref float rotation)
		{
			rotation = npc.rotation;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
			{
				npc.lifeMax = 35000 + ((numPlayers) * 4000);
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
			//TGEMWorld world = GetModWorld<TGEMWorld>();
			
			if (npc.life <= (int)(npc.lifeMax/2) && despawn == false)
			{		
				if (phase2transition == false)
				{
					Main.NewText("Titan Rock enrages!", 255, 25, 0);
					Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
					TGEMWorld.TremorTime = 100;
					timer = 0;
					phase2transition = true;
				}
				
				if (falltimer <= 50 && falltimer >= 20)
				{
					timer++;
				}
				
				if (spawnedMiniTitans1 == false) //spawn the 1st pair of mini titans
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					spawnedMiniTitans1 = true;
				}
				
				if (spawnedMiniTitans2 == false && Main.expertMode && npc.life <= (int)(npc.lifeMax/4))
				{ //spawn the 2nd pair
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniTitan"));
					spawnedMiniTitans2 = true;
				}
				
				if (timer <= 30)
				{
					gayvector = new Vector2(0f, -5f);
					npc.rotation += 0.20f; //rotation
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 800f)
					{
						npc.ai[2] = 0f;
						npc.ai[1] = 1f;
						npc.TargetClosest(true);
						npc.netUpdate = true;
					}
					npc.velocity.X = 0; //make sure it doesn't break when entering the 2nd phase
					if (falltimer == 0)//teleport above the player and create a ring of lasers
					{
						int A = Main.rand.Next(-250, 250) * 2;
						npc.position.X = player.Center.X + A;
						npc.position.Y = player.position.Y - (Main.screenHeight);
						teleportF = player.position.Y + (Main.screenHeight);
						canTPAgain = true;
						
						for (int m = 0; m <= 30; m++)
						{
							int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
							Main.dust[dust].noGravity = true;
							Main.dust[dust].scale = 3.5f;
						}
						falltimer += 1;
						Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
						npc.netUpdate = true;
					}
					
					if (falltimer >= 0)
					{
						if (npc.life <= (int)(npc.lifeMax / 4) && Main.expertMode)
						{
							npc.velocity.Y = 18f;
						}
						
						else
						{
							npc.velocity.Y = 17f;
						}
						
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
						falltimer++;
					}
					
					if (npc.position.X > player.position.X)
					{
						if (npc.life <= (int)(npc.lifeMax / 4))
						{
							npc.velocity.X = -5f;
						}
						
						else
						{
							npc.velocity.X = -3f;
						}
					}
					
					if (npc.position.X < player.position.X)
					{
						if (npc.life <= (int)(npc.lifeMax / 4))
						{
							npc.velocity.X = 5f;
						}
						
						else
						{
							npc.velocity.X = 3f;
						}
					}
					
					
					if (npc.Center.Y >= teleportF && canTPAgain == true && timer <= 21)
					{
						falltimer = 0;
						for (int r = 0; r <= 30; r++)
						{
							int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
							Main.dust[dust].noGravity = true;
							Main.dust[dust].scale = 2.5f;
						}	
						TGEMWorld.TremorTime = 100;
						npc.netUpdate = true;
					}
				}
				
				if (timer >= 30 && falltimer <= 50 && falltimer >= 20 && transgender == 0)
				{
					timer2++;
					
					npc.rotation += 0.20f;
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					
					if (timer2 >= 5)
					{
						Vector2 newVect = gayvector.RotatedBy(System.Math.PI / 25);
						
						gayvector = newVect;
						homovector = gayvector.RotatedBy(System.Math.PI);
						bivector = gayvector.RotatedBy(System.Math.PI / 2);
						lesvector = gayvector.RotatedBy((3*System.Math.PI) / 2);
						
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, gayvector.X * 1.4f, gayvector.Y * 1.4f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, homovector.X * 1.4f, homovector.Y * 1.4f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						if (timer <= 200 || timer >= 250 && timer <= 350|| timer >= 400)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, lesvector.X * 1.4f, lesvector.Y * 1.4f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, bivector.X * 1.4f, bivector.Y * 1.4f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						}
						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
						timer2 = 0;
					}
				}
				
				
				if (timer >= 30 && falltimer <= 50 && falltimer >= 20 && transgender == 1)
				{
					timer2++;
					
					npc.rotation += 0.20f;
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					
					if (timer2 >= 5)
					{
						Vector2 newVect = gayvector;
						if (timer <= 230)
						{
						
							newVect = gayvector.RotatedBy(System.Math.PI / -32);
						}
						else
						{
						
							newVect = gayvector.RotatedBy(System.Math.PI / 32);
						}
						
						gayvector = newVect;
						homovector = gayvector.RotatedBy(System.Math.PI);
						bivector = gayvector.RotatedBy(System.Math.PI / 2);
						lesvector = gayvector.RotatedBy((3*System.Math.PI) / 2);
						
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, gayvector.X, gayvector.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, homovector.X, homovector.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, lesvector.X, lesvector.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, bivector.X, bivector.Y, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
						timer2 = 0;
					}
				}
				
				if (Main.rand.Next(400) == 0)
				{
					int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TitanBat"));
					npc.netUpdate = true;
					Main.projectile[n].netUpdate = true;
				}
				
				if (Main.rand.Next(500) == 0)
				{
					int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
					npc.netUpdate = true;
					Main.projectile[n].netUpdate = true;
				}
								
				if (timer >= 400)
				{
					timer = 0;
					transgender++;
					if (transgender > 1)
					{
						transgender = 0; 
					}
				}
				
			}
				
			else
			{
				timer++;
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
					
					if (Main.rand.Next(500) == 0)
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
							int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), 25, 1, Main.myPlayer, 0, 0);
							Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
							Main.projectile[p].netUpdate = true;
						}
					}
					if (timer == 50 || timer == 150 || timer == 250)
					{	
						if (npc.life <= 30000 && Main.expertMode)
						{
							for (int i = 0; i < 3; ++i)
							{
								Vector2 direction = Main.player[npc.target].Center - npc.Center;
								direction.Normalize();
								float sX = direction.X * 8f;
								float sY = direction.Y * 8f;
								sX += (float)Main.rand.Next(-15, 15) * 0.1f;
								sY += (float)Main.rand.Next(-15, 15) * 0.1f;
								int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), 30, 1, Main.myPlayer, 0, 0);
								Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
								Main.projectile[p].netUpdate = true;
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
						
						if (npc.life <= 30000 && Main.expertMode)
						{
							newVect = gayvector.RotatedBy(System.Math.PI / 27);
							newVect2 = homovector.RotatedBy(System.Math.PI / 27);
						}
						gayvector = newVect;
						homovector = newVect2;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, gayvector.X * 1.5f, gayvector.Y * 1.5f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, homovector.X * 1.5f, homovector.Y * 1.5f, mod.ProjectileType("Ball"), 20, 1, Main.myPlayer, 0, 0);
						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
						timer2 = 0;
					}
				}
				
				timer3++;
				if (Main.expertMode && timer3 == 500)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
				}
				
				if (npc.life <= 30000 && bisexual2 == false)
				{
					int ok = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
					Main.npc[ok].lifeMax = 8000;
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
				if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
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
				int amountToDrop = Main.rand.Next(12,16);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpaceRockFragment"), amountToDrop);
				
				switch (Main.rand.Next (8))
				{
					case 0:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserbladeKatana"), 1);
						break;
					case 1:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NeedleBow"), 1);
						break;
					case 2:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserbeamStaff"), 1);
						break;
					case 3:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BeamSlicer"), Main.rand.Next(210, 240));
						break;
					case 4:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizedBlaster"), 1);
						break;
					case 5:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TitanSpin"), 1);
						break;
					case 6:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TitanicCrusher"), 1);
						break;
					case 7:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientLauncher"), 1);
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 771, Main.rand.Next(110, 140));
						break;
				}
			}
			if (!TGEMWorld.downedTitanRock)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmiCrystal"), 1);
			}
			if (TGEMWorld.downedTitanRock && Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmiCrystal"), 1);
			}
			TGEMWorld.downedTitanRock = true;			
		}
	}
}
