using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Delirium
{
    public class Delirium : ModNPC
    {
		int timer = 0;
		int shootTimer = 0;
		
        public override void SetDefaults()
        {
            npc.name = "Delirium";
            npc.displayName = "Delirium";
            npc.aiStyle = -1;
            npc.lifeMax = 500000;
            npc.damage = 75;
            npc.defense = 13;
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            npc.value = Item.buyPrice(0, 2, 0, 0);
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit54;
			npc.DeathSound = SoundID.NPCDeath52;
            music = 12;
			Main.npcFrameCount[npc.type] = 5;
			npc.scale = 1.25f;
			npc.npcSlots = 5;
        }

        public override void AI()
        {
			npc.TargetClosest(true);
            Player player = Main.player[npc.target];
			timer++;
			shootTimer++;
			
			if (shootTimer >= 40)
			{
				for (int i = 0; i < 2; ++i)
				{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					float sX = direction.X * 10f;
					float sY = direction.Y * 10f;
					sX += (float)Main.rand.Next(-60, 61) * 0.02f;
					sY += (float)Main.rand.Next(-60, 61) * 0.02f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("OblivionWave"), 75, 1, Main.myPlayer, 0, 0);
				}
				shootTimer = 0;
			}
			if (timer == 400)
			{
			
			}
			
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
			
		}
		
		public override bool PreNPCLoot()
		{
			return false;
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
