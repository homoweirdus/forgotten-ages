using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	[AutoloadBossHead]
    public class GhastlyEnt : ModNPC
    {
		int timer = 0;
		int moveSpeed = 0;
		int moveSpeedY = 0;
		int shootTimer = 0;
		int shootTimerB = 0;
		int shootTimerC = 0;
		int moveSpeedx2 = 0;
		int moveSpeedy2 = 0;
		int appleTimer = 0;
		
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 2700;
            npc.damage = 25;
            npc.defense = 15;
            npc.knockBackResist = 0f;
            npc.width = 76;
            npc.height = 158;
            npc.value = Item.buyPrice(0, 2, 0, 0);
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
            music = 12;
			npc.scale = 1.25f;
			npc.npcSlots = 5;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghastly Ent");
			Main.npcFrameCount[npc.type] = 6;
		}

        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			timer++;
			
			
				if (timer == 3 || timer == 100 || timer == 200 || timer == 300 || timer == 400 || timer == 500)
				{
					npc.alpha = 0;
					moveSpeed = 0;
					moveSpeedY = 0;
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					npc.velocity.Y = direction.Y * 9f;
					npc.velocity.X = direction.X * 9f;
				}
			
				if (timer == 75 || timer == 175 || timer == 275 || timer == 375 || timer == 475)
				{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					npc.velocity.Y = direction.Y * 1f;
					npc.velocity.X = direction.X * 1f;
					
				}
			
			
			
			if (timer >= 600 && timer <= 1500)
			{
				if (npc.Center.X >= player.Center.X && moveSpeed >= -50) // flies to players x position
				{
					moveSpeed--;
				}
					
				if (npc.Center.X <= player.Center.X && moveSpeed <= 50)
				{
					moveSpeed++;
				}
				
					npc.velocity.X = moveSpeed * 0.2f;
				
				if (npc.Center.Y >= player.Center.Y - 350f && moveSpeedY >= -35) //Flies to players Y position
				{
					moveSpeedY--;
				}
					
				if (npc.Center.Y <= player.Center.Y - 350f && moveSpeedY <= 35)
				{
					moveSpeedY++;
				}
				

					npc.velocity.Y = moveSpeedY * 0.1f;

				
				shootTimer++;
				if (shootTimer == 50)
				{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 12f, direction.Y * 12f, mod.ProjectileType("SapBall"), 12, 1, Main.myPlayer, 0, 0);
				shootTimer = 0;
				}
			}
			
				
			if (timer >= 1500) //Phase 3
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					
				shootTimerB++;
				
				
				if (shootTimerB == 80)
					{
						for (int i = 0; i < 50; ++i)
						{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 61);      
						Main.dust[dust].scale = 1.5f;
						}
						int A = Main.rand.Next(-250, 250) * 3;
						int B = Main.rand.Next(-100, 100) - 400;
						npc.position.X = player.Center.X + A;
						npc.position.Y = player.Center.Y + B;
						shootTimerB = 0;
						for (int i = 0; i < 3; ++i)
						{
							Vector2 direction = Main.player[npc.target].Center - npc.Center;
							direction.Normalize();
							float sX = direction.X * 6.5f;
							float sY = direction.Y * 6.5f;
							sX += (float)Main.rand.Next(-60, 61) * 0.05f;
							sY += (float)Main.rand.Next(-60, 61) * 0.05f;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Leafnado"), 12, 1, Main.myPlayer, 0, 0);
						}
					}
					
					if (timer == 2300) // this is where timer resets on expert mode
					{
						timer = 0;
					}
				}
				
				if (Main.expertMode && npc.life <= 1750) //FINAL PHASE BOIS
					{
						timer = 0;
						shootTimerC++;
						appleTimer++;
						
						if (shootTimerC == 40)
						{
						Vector2 direction2 = Main.player[npc.target].Center + new Vector2(player.velocity.X * 2f, player.velocity.Y * 2f) - npc.Center;
						direction2.Normalize();
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction2.X * 15f, direction2.Y * 15f, mod.ProjectileType("Air"), 12, 1, Main.myPlayer, 0, 0);
						shootTimerC = 0;
						}
						
						if (appleTimer == 150)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10f, -1f, mod.ProjectileType("ForestPortal"), 12, 1, Main.myPlayer, 0, 0);
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10f, -1f, mod.ProjectileType("ForestPortal"), 12, 1, Main.myPlayer, 0, 0);
							appleTimer = 0;
						}
						
							if (npc.Center.X >= player.Center.X && moveSpeedx2 >= -50) // flies to players x position
						{
							moveSpeedx2--;
						}
					
						if (npc.Center.X <= player.Center.X && moveSpeedx2 <= 50)
						{
							moveSpeedx2++;
						}
				
						npc.velocity.X = moveSpeedx2 * 0.15f;
				
						if (npc.Center.Y >= player.Center.Y && moveSpeedy2 >= -35) //flies to players Y position
						{
							moveSpeedy2--;
						}
					
						if (npc.Center.Y <= player.Center.Y && moveSpeedy2 <= 35)
						{
							moveSpeedy2++;
						}
				

					npc.velocity.Y = moveSpeedy2 * 0.07f;
					}
					
			if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				timer = 0;
				shootTimerC = 0;
            }
			
		}
					public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
				public override void NPCLoot()
			{
				TGEMWorld.downedGhastlyEnt = true;
				if (Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("MegaTreeBag")));
				}
				else
				{
					int amountToDrop = Main.rand.Next(10,30);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForestEnergy"), amountToDrop);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, (amountToDrop * 3));
					
				if (Main.rand.Next(7) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MegaTreeMask"), 1);
					}
				}
			}
        }
    }
