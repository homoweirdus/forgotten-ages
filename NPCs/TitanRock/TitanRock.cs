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
		bool bisexual = false;
		bool bisexual2 = false;
		Vector2 gayvector = new Vector2(0f, -3f);
		Vector2 homovector = new Vector2(0f, 3f);
		
        public override void SetDefaults()
        {
            npc.name = "Titan Rock";
            npc.displayName = "Titan Rock";
            npc.aiStyle = -1;
            npc.lifeMax = 2600;
            npc.damage = 30;
            npc.defense = 13;
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
            music = 12;
			Main.npcFrameCount[npc.type] = 4;
			npc.scale = 1.25f;
			npc.npcSlots = 5;
        }

        public override void AI()
        {
			npc.TargetClosest(true);
            Player player = Main.player[npc.target];
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
					
					if (Main.rand.Next(80) == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TitanBat"));
				}
				
				if (timer == 100 || timer == 200)
				{	
					for (int i = 0; i < 4; ++i)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						float sX = direction.X * 4f;
						float sY = direction.Y * 4f;
						sX += (float)Main.rand.Next(-60, 61) * 0.02f;
						sY += (float)Main.rand.Next(-60, 61) * 0.02f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball"), 12, 1, Main.myPlayer, 0, 0);
					}
				}
				if (timer == 50 || timer == 150 || timer == 250)
				{	
					if (npc.life <= 1000 && Main.expertMode)
					{
						for (int i = 0; i < 2; ++i)
						{
							Vector2 direction = Main.player[npc.target].Center - npc.Center;
							direction.Normalize();
							float sX = direction.X * 4f;
							float sY = direction.Y * 4f;
							sX += (float)Main.rand.Next(-60, 61) * 0.02f;
							sY += (float)Main.rand.Next(-60, 61) * 0.02f;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball"), 12, 1, Main.myPlayer, 0, 0);
						}
					}
				}
			}
			
			
			if (timer >= 350)
			{
				if (timer == 300)
				{
					gayvector = new Vector2(0f, -3f);
					homovector = new Vector2(0f, 3f);
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
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, gayvector.X, gayvector.Y, mod.ProjectileType("Ball"), 22, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, homovector.X, homovector.Y, mod.ProjectileType("Ball"), 22, 1, Main.myPlayer, 0, 0);
					timer2 = 0;
					
				}
			}
			
			if (npc.life <= 3000 && Main.expertMode && bisexual == false)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
				bisexual = true;
			}
			
			if (npc.life <= 1000 && bisexual2 == false)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
				bisexual2 = true;
			}
			
			if (timer >= 650)
			{
				timer = 0;
			}
					
			if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				timer = 0;
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
        }
    }
