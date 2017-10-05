using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class SapSlime : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 60;
			npc.height = 48;
			npc.damage = 120;
			npc.defense = 40;
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;;
			npc.lifeMax = 10000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 10000f;
			npc.knockBackResist = 0f;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
			Texture2D texture2D3 = Main.npcTexture[npc.type];
			int num156 = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
			int y3 = num156 * (int)npc.frameCounter;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			int arg_5ADA_0 = npc.type;
			int arg_5AE7_0 = npc.type;
			int arg_5AF4_0 = npc.type;
			int num157 = 10;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			
			int num161 = num159;
			while (npc.velocity != Vector2.Zero &&((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157)))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = npc.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Orange, 0.5f);
				
				IL_6881:
				num161 += num158;
				continue;
				IL_6899:
				float num164 = (float)(num157 - num161);
				if (num158 < 0)
				{
					num164 = (float)(num159 - num161);
				}
				color26 *= num164 / ((float)NPCID.Sets.TrailCacheLength[npc.type] * 1.5f);
				Vector2 value4 = (npc.oldPos[num161]);
				float num165 = npc.rotation;
				SpriteEffects effects = spriteEffects;
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = npc.GetAlpha(color25);
			return true;
		}
		
		public override void AI()
        {
			Player player = Main.player[npc.target];
			
			npc.noTileCollide = false;
			npc.noGravity = false;
			if ((double) npc.ai[0] != 7.0 && Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].dead)
				{
					npc.ai[0] = 7f;
					npc.ai[1] = 0.0f;
					npc.ai[2] = 0.0f;
					npc.ai[3] = 0.0f;
				}
			}
			if ((double) npc.ai[0] == 0.0)
			{
				npc.TargetClosest(true);
				Vector2 vector2 = (Main.player[npc.target].Center - npc.Center);
				if (npc.velocity.X == 0.0 && npc.velocity.Y <= 100.0 && (!npc.justHit && (double) vector2.Length() >= 80.0))
					return;
				npc.ai[0] = 1f;
				npc.ai[1] = 0.0f;
			}
			else if ((double) npc.ai[0] == 1.0)
			{
				npc.ai[1]++;
				if ((double) npc.ai[1] <= 36.0)
					return;
				npc.ai[0] = 2f;
				npc.ai[1] = 0.0f;
			}
			else if ((double) npc.ai[0] == 2.0)
			{
				Vector2 vector2 = (Main.player[npc.target].Center - npc.Center);
				if (vector2.Length() > 600.0)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0.0f;
					npc.ai[2] = 0.0f;
					npc.ai[3] = 0.0f;
				}
				if (npc.velocity.Y == 0.0)
				{
					npc.TargetClosest(true);
					npc.velocity.X = npc.velocity.X * 0.85f;
					npc.ai[1] = npc.ai[1] + 1f;
					float num1 = (float) (15.0 + 30.0 * ((double) npc.life / (double) npc.lifeMax));
					float num2 = (float) (5.0 + 4.0 * (1.0 - (double) npc.life / (double) npc.lifeMax));
					float num3 = 6f;
					if (!Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
						num3 += 2f;
					if ((double) npc.ai[1] > (double) num1)
					{
						npc.ai[3] = npc.ai[3] + 1f;
						if ((double) npc.ai[3] >= 3.0)
						{
							npc.ai[3] = 0.0f;
							num3 *= 2f;
							num2 /= 2f;
						}
						npc.ai[1] = 0.0f;
						npc.velocity.Y = npc.velocity.Y - num3;
						npc.velocity.X = (num2 * npc.direction);
					}
				}
				
				else
				{
					npc.velocity.X = npc.velocity.X * 0.99f;
					if (npc.direction < 0 && npc.velocity.X > -1.0)
						npc.velocity.X = -1;
					if (npc.direction > 0 && npc.velocity.X < 1.0)
						npc.velocity.X = 1;
				}
				npc.ai[2] = npc.ai[2] + 1f;
				if ((double) npc.ai[2] <= 210.0 || npc.velocity.Y != 0.0 || Main.netMode == 1)
					return;
				switch (Main.rand.Next(3))
				{
					case 0:
						npc.ai[0] = 3f;
						break;
					case 1:
						npc.ai[0] = 4f;
						npc.noTileCollide = true;
						npc.velocity.Y = -8;
						break;
					case 2:
						npc.ai[0] = 6f;
						break;
					default:
						npc.ai[0] = 2f;
						break;
				}
				npc.ai[1] = 0.0f;
				npc.ai[2] = 0.0f;
				npc.ai[3] = 0.0f;
			}
			else if ((double) npc.ai[0] == 3.0)
			{
				npc.velocity.X = npc.velocity.X * 0.85f;
				npc.ai[1] = npc.ai[1] + 1f;
				if ((double) npc.localAI[0] <= 0)
				{
					if (Main.rand.Next(3) == 0)
					{
						for (int index = 0; index < 5; ++index)
						{
							Vector2 vector2 = new Vector2(index - 2, 2);
							vector2.X = vector2.X * (1f + (float) Main.rand.Next(-50, 51) * 0.0199999995529652f);
							vector2.Y = vector2.Y * (1f + (float) Main.rand.Next(-50, 51) * 0.0199999995529652f);
							vector2.Normalize();
							vector2 = (vector2 * (float) (3.0 + (float) Main.rand.Next(-50, 51) * 0.00999999977648258f));
							Projectile.NewProjectile((float) npc.Center.X, (float) npc.Center.Y, (float) vector2.X, (float) vector2.Y, mod.ProjectileType("MiniSap"), npc.damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);
							Main.PlaySound(SoundID.NPCHit1, npc.position);
						}
					}
					else if (Main.rand.Next(2) == 0)
					{
						for (int index = 0; index < 3; ++index)
						{
							Vector2 direction = (Main.player[npc.target].Center + (Main.player[npc.target].velocity * 20f)) - npc.Center;
							direction.Normalize();
							direction.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 8f, direction.Y * 8f, mod.ProjectileType("SapBall"), npc.damage, 1, Main.myPlayer, 0, 0);
							Main.PlaySound(SoundID.NPCHit1, npc.position);
						}
					}
					else
					{
						NPC sap = Main.npc[NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SmolSap"))];
						if (Main.expertMode)
						{
							sap.lifeMax = Main.rand.Next(500, 1200);
						}
					}
					npc.localAI[0] = 60f;
				}
				
				
				if (npc.localAI[0] > 0)
					npc.localAI[0]--;
				
				if ((double) npc.ai[1] >= 180.0)
				{
					npc.ai[0] = 2f;
					npc.ai[1] = 0.0f;
				}
				if (!Main.expertMode)
					return;
			}
			else if ((double) npc.ai[0] == 4.0)
			{
				npc.noTileCollide = true;
				npc.noGravity = true;
				if (npc.velocity.X < 0.0)
					npc.direction = -1;
				else
					npc.direction = 1;
				npc.TargetClosest(true);
				Vector2 center = Main.player[npc.target].Center;
				center.Y -= 350f;
				Vector2 vector2_1 = (center - npc.Center);
				if ((double) npc.ai[2] == 1.0)
				{
					npc.ai[1] = npc.ai[1] + 1f;
					Vector2 vector2_2 = (Main.player[npc.target].Center - npc.Center);
					vector2_2.Normalize();
					Vector2 vector2_3 = (vector2_2 * 8f);
					npc.velocity = (((npc.velocity* 4f) + vector2_3)/ 5f);
					if ((double) npc.ai[1] <= 6.0)
						return;
					npc.ai[1] = 0.0f;
					npc.ai[0] = 4.1f;
					npc.ai[2] = 0.0f;
					npc.velocity = vector2_3;
				}
				else if ((double) Math.Abs((float) (npc.Center.X - Main.player[npc.target].Center.X)) < 40.0 && npc.Center.Y < Main.player[npc.target].Center.Y - 300.0)
				{
					npc.ai[1] = 0.0f;
					npc.ai[2] = 1f;
				}
				else
				{
					vector2_1.Normalize();
					npc.velocity = (((npc.velocity * 5f)+ (vector2_1 * 12f))/ 6f);
				}
			}
			else if ((double) npc.ai[0] == 4.09999990463257)
			{
				npc.knockBackResist = 0.0f;
				if ((double) npc.ai[2] == 0.0 && Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1) && !Collision.SolidCollision(npc.position, npc.width, npc.height))
					npc.ai[2] = 1f;
				if (npc.position.Y + (double) npc.height >= Main.player[npc.target].position.Y || npc.velocity.Y <= 0.0)
				{
					npc.ai[1]++;
					if ((double) npc.ai[1] > 10.0)
					{
						npc.ai[0] = 2f;
						npc.ai[1] = 0.0f;
						npc.ai[2] = 0.0f;
						npc.ai[3] = 0.0f;
						if (Collision.SolidCollision(npc.position, npc.width, npc.height))
							npc.ai[0] = 5f;
					}
				}
				else if ((double) npc.ai[2] == 0.0)
				{
					npc.noTileCollide = true;
					npc.noGravity = true;
					npc.knockBackResist = 0.0f;
				}
				npc.velocity.Y += 0.2f;
				if (npc.velocity.Y <= 16.0)
					return;
				npc.velocity.Y = 16;
			}
			else if ((double) npc.ai[0] == 5.0)
			{
				if (npc.velocity.X > 0.0)
					npc.direction = 1;
				else
					npc.direction = -1;
				npc.spriteDirection = npc.direction;
				npc.noTileCollide = true;
				npc.noGravity = true;
				npc.knockBackResist = 0.0f;
				Vector2 vector2 = (Main.player[npc.target].Center - npc.Center);
				vector2.Y -= 4f;
				if ((vector2.Length() < 200 && !Collision.SolidCollision(npc.position, npc.width, npc.height)))
				{
					npc.ai[0] = 2f;
					npc.ai[1] = 0.0f;
					npc.ai[2] = 0.0f;
					npc.ai[3] = 0.0f;
				}
				if ((double) vector2.Length() > 10.0)
				{
					vector2.Normalize();
					vector2 = (vector2 * 10f);
				}
				npc.velocity = (((npc.velocity * 4f) + vector2)/ 5f);
			}
			else if ((double) npc.ai[0] == 6.0)
			{
				npc.knockBackResist = 0.0f;
				if (npc.velocity.Y == 0.0)
				{
					npc.TargetClosest(true);
					npc.velocity.X *= 0.8f;
					npc.ai[1]++;
					if ((double) npc.ai[1] > 5.0)
					{
						npc.ai[1] = 0.0f;
						npc.velocity.Y -= 4f;
						if (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height < npc.Center.Y)
						{
							npc.velocity.Y -= 1.25f;
						}
						if (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height < npc.Center.Y - 40.0)
						{
							npc.velocity.Y -= 1.5f;
						}
						if (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height < npc.Center.Y - 80.0)
						{
							npc.velocity.Y -= 1.75f;
						}
						if (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height < npc.Center.Y - 120.0)
						{
							npc.velocity.Y -= 2f;
						}
						if (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height < npc.Center.Y - 160.0)
						{
							npc.velocity.Y -= 2.25f;
						}
						if (Main.player[npc.target].position.Y + (double) Main.player[npc.target].height < npc.Center.Y - 200.0)
						{
							npc.velocity.Y -= 2.5f;
						}
						if (!Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
						{
							npc.velocity.Y -= 2f;
						}
						npc.velocity.X = 12 * npc.direction;
						npc.ai[2]++;
					}
				}
				else
				{
					npc.velocity.X *= 0.98f;
					if (npc.direction < 0 && npc.velocity.X > -8)
						npc.velocity.X = -8;
					if (npc.direction > 0 && npc.velocity.X < 8)
						npc.velocity.X = 8;
				}
				if ((double) npc.ai[2] < 3.0 || npc.velocity.Y != 0.0)
					return;
				npc.ai[0] = 2f;
				npc.ai[1] = 0.0f;
				npc.ai[2] = 0.0f;
				npc.ai[3] = 0.0f;
			}
			else
			{
				if ((double) npc.ai[0] != 7.0)
					return;
				npc.damage = 0;
				npc.life = npc.lifeMax;
				npc.defense = 9999;
				npc.noTileCollide = true;
				npc.alpha = npc.alpha + 7;
				if (npc.alpha > (int) byte.MaxValue)
					npc.alpha = (int) byte.MaxValue;
				npc.velocity.X *= 0.98f;
			}
		}
		
		public override void NPCLoot()
		{
			Projectile.NewProjectile((int)npc.position.X, (int)npc.position.Y, 0, 0, mod.ProjectileType("Sap"), npc.damage, 0f, Main.myPlayer);
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Sap Slime");
			Main.npcFrameCount[npc.type] = 2;
			animationType = NPCID.BlueSlime;
		}
	}
}
