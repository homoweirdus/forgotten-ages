using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class LivingMortar : ModNPC
	{
		int ai;
		bool hasShot = false;
		public override void SetDefaults()
		{
			npc.width = 48;
			npc.height = 40;
			npc.damage = 28;
			npc.defense = 12;
			npc.lifeMax = 80;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Mortar");
			Main.npcFrameCount[npc.type] = 9;
		}
		
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.TargetClosest(true);
			//edited vanilla code below don't kill me pls
			bool flag6 = npc.type == 381 || npc.type == 382 || npc.type == 520;
			bool flag7 = npc.type == 426;
			bool flag8 = true;
			int num1 = -1;
			int num2 = -1;
			if (npc.confused)
			{
				npc.ai[2] = 0.0f;
			}
			else
			{
				if ((double) npc.ai[1] > 0.0)
					--npc.ai[1];
				if (npc.justHit)
				{
					npc.ai[1] = 30f;
					npc.ai[2] = 0.0f;
				}
				int num3 = 60;
				bool flag9 = false;
				int num4 = 0;
				if ((double) npc.ai[2] > 0.0)
				{
					if ((double) npc.ai[1] <= (double) num4)
					{
						float num5 = 9f;
						Vector2 vector2 = npc.Center;
						float num7 = (float) (Main.player[npc.target].position.X + (double) Main.player[npc.target].width * 0.5 - vector2.X);
						float num8 = Math.Abs(num7) * 0.1f;
						float num9 = (float) (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height * 0.5 - vector2.Y) - num8;
						float num14 = (float) Math.Sqrt((double) num7 * (double) num7 + (double) num9 * (double) num9);
						npc.netUpdate = true;
						float num15 = num5 / num14;
						float SpeedX = num7 * num15;
						float SpeedY = num9 * num15;
						int Damage = (Main.expertMode) ? 45 : 30;
						int Type = mod.ProjectileType("wooball");
						float num16 = (vector2.X + SpeedX);
						vector2.X = num16;
						double num17 = vector2.Y + SpeedY;
						vector2.Y = (float) num17;
						if (Main.netMode != 1)
						{
							Projectile.NewProjectile((float) vector2.X, (float) vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);
						}
						npc.ai[2] = (double) Math.Abs(SpeedY) <= (double) Math.Abs(SpeedX) * 2.0 ? ((double) Math.Abs(SpeedX) <= (double) Math.Abs(SpeedY) * 2.0 ? ((double) SpeedY <= 0.0 ? 4f : 2f) : 3f) : ((double) SpeedY <= 0.0 ? 5f : 1f);
						hasShot = true;
					}
					if (npc.velocity.Y != 0.0 || (double) npc.ai[1] <= 0.0)
					{
						hasShot = false;
						npc.ai[2] = 0.0f;
						npc.ai[1] = 0.0f;
					}
					
					else if (!flag6 || num1 != -1 && (double) npc.ai[1] >= (double) num1 && (double) npc.ai[1] < (double) (num1 + num2) && (!flag7 || npc.velocity.Y == 0.0))
					{
						float num5 = npc.velocity.X * 0.899999976158142f;
						npc.velocity.X = num5;
						npc.spriteDirection = npc.direction;
					}
				}
				else if ((double) npc.ai[2] <= 0.0 && npc.velocity.Y == 0.0 && ((double) npc.ai[1] <= 0.0 && !Main.player[npc.target].dead))
				{
					bool flag10 = Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height);
					if ((double) Main.player[npc.target].stealth == 0.0 && Main.player[npc.target].itemAnimation == 0)
						flag10 = false;
					if (flag10)
					{
						float num5 = 10f;
						Vector2 vector2 = npc.Center;
						float num6 = (float) (Main.player[npc.target].position.X + (double) Main.player[npc.target].width * 0.5 - vector2.X);
						float num7 = Math.Abs(num6) * 0.1f;
						float num8 = (float) (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height * 0.5 - vector2.Y) - num7;
						float num9 = num6 + (float) Main.rand.Next(-40, 41);
						float num10 = num8 + (float) Main.rand.Next(-40, 41);
						float num11 = (float) Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
						float num12 = 700f;
						if ((double) num11 < (double) num12)
						{
							npc.netUpdate = true;
							float num14 = npc.velocity.X * 0.5f;
							npc.velocity.X = num14;
							float num15 = num5 / num11;
							float num16 = num9 * num15;
							float num17 = num10 * num15;
							npc.ai[2] = 3f;
							npc.ai[1] = (float) num3;
							npc.ai[2] = (double) Math.Abs(num17) <= (double) Math.Abs(num16) * 2.0 ? ((double) Math.Abs(num16) <= (double) Math.Abs(num17) * 2.0 ? ((double) num17 <= 0.0 ? 4f : 2f) : 3f) : ((double) num17 <= 0.0 ? 5f : 1f);
						}
					}
				}
				if ((double) npc.ai[2] <= 0.0 || flag6 && (num1 == -1 || (double) npc.ai[1] < (double) num1 || (double) npc.ai[1] >= (double) (num1 + num2)))
				{
					float num5 = 1f;
					float num6 = 0.07f;
					float num7 = 0.8f;
					bool flag10 = false;
					if (((npc.velocity.X < -(double) num5 ? 1 : (npc.velocity.X > (double) num5 ? 1 : 0)) | (flag10 ? 1 : 0)) != 0)
					{
						if (npc.velocity.Y == 0.0)
							npc.velocity = (npc.velocity * num7);
					}
					else if (npc.velocity.X < (double) num5 && npc.direction == 1)
					{
						float num8 = npc.velocity.X + num6;
						npc.velocity.X = num8;
						if (npc.velocity.X > num5)
							npc.velocity.X = num5;
					}
					else if (npc.velocity.X > -(double) num5 && npc.direction == -1)
					{
						float num8 = npc.velocity.X - num6;
						npc.velocity.X = num8;
						if (npc.velocity.X < -num5)
							npc.velocity.X =  -num5;
					}
				}
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			int num1 = 1;
			if (npc.velocity.Y == 0.0)
			{
				if (npc.direction == 1)
					npc.spriteDirection = 1;
				if (npc.direction == -1)
					npc.spriteDirection = -1;
			}
			if ((double) npc.ai[2] > 0.0)
			{
				npc.frameCounter += 0.2f; 
				npc.frameCounter %= 5; 
				int frame = (int)npc.frameCounter + 4; 
				npc.frame.Y = frame * frameHeight;
			}
			else
			{
				npc.frameCounter += 0.25f; 
				npc.frameCounter %= 4; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight;
			}
		}
		
		public override void NPCLoot()
		{
			
			for (int m = 0; m <= 5; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
			}
			
			for (int m = 0; m <= 10; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 191);
			}
					
			if(Main.rand.Next(20) == 0)
			{
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
			}
		}
	}
}
