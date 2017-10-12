using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Acheron
{
	//[AutoloadBossHead]
    public class Acheron : ModNPC
    {
		Vector2 TPLocation;
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 7800;
            npc.damage = 28;
            npc.defense = 28;
            npc.knockBackResist = 0f;
            npc.width = 98;
            npc.height = 112;
            npc.value = 100000;
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit49;
			npc.DeathSound = SoundID.NPCDeath6;
            music = 14;
			npc.npcSlots = 5;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
			{
				npc.lifeMax = 9500 + ((numPlayers) * 3000);
				npc.damage = 38;
			}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acheron");
			Main.npcFrameCount[npc.type] = 6;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
			Texture2D texture2D3 = mod.GetTexture("NPCs/Acheron/AcheronGhost");
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
			while (((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157)))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = npc.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Blue, 0.5f);
				color26.A += (byte)(150);
				
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
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(15f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(-15f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = npc.GetAlpha(color25);
			return true;
		}

        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			npc.ai[0]++;
			
			if (npc.alpha > 255)
				npc.alpha = 255;
			
			if (npc.ai[0] < 120)
			{
				Move(player);
			}
			else if (npc.ai[0] < 135)
			{
				Teleport(player);
			}
			else if (npc.ai[0] < 180)
			{
				Souls(player);
			}
			else
			{
				npc.ai[0] = 0;
				npc.ai[2] = 0;
			}
					
			if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
            }
			
		}
		
		public void Move(Player player)
		{
			npc.TargetClosest(true);
			Vector2 vector2;
			vector2 = new Vector2(npc.Center.X, npc.Center.Y);
			float num1 = (float) (player.Center.X - vector2.X);
			float num2 = (float) (player.Center.Y - vector2.Y);
			float num3 = 18f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
			float num4 = num1 * num3;
			float num5 = num2 * num3;
			npc.velocity.X = ((npc.velocity.X * 100f + (float) num4) / 101f);
			npc.velocity.Y = ((npc.velocity.Y * 100f + (float) num5) / 101f);
		}
		
		public void Teleport(Player player)
		{
			Vector2 vel = new Vector2(player.Center.X, player.Center.Y - 350) - npc.Center;
			vel.Normalize();
			vel *= 25;
			npc.velocity = vel;
			if (npc.ai[2] == 0)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AcheronGhost"));
				npc.ai[2]++;
			}
		}
		
		public void Souls(Player player)
		{
			npc.velocity = Vector2.Zero;
			if (npc.ai[0] == 150)
			{
				for (int index = 0; index < 4; index++)
				{
					Vector2 Position = new Vector2(npc.Center.X + Main.rand.Next(-15, 16), npc.Center.Y + Main.rand.Next(-6, 7));
					Vector2 Vel = player.Center - Position;
					Vel.Normalize();
					Vel *= 10;
					Projectile.NewProjectile(Position.X, Position.Y, Vel.X, Vel.Y, mod.ProjectileType("HomingSoul"), (int)(npc.damage/2), 1, Main.myPlayer, 0, 0);
				}
			}
			
			if (npc.ai[0] == 170)
			{
				for (int index = 0; index < 2; index++)
				{
					Vector2 Position = new Vector2(npc.Center.X + Main.rand.Next(-15, 16), npc.Center.Y + Main.rand.Next(-6, 7));
					Vector2 Vel = player.Center - Position;
					Vel.Normalize();
					Vel *= 10;
					Vel += player.velocity;
					Projectile.NewProjectile(Position.X, Position.Y, Vel.X, Vel.Y, mod.ProjectileType("HomingSoul"), (int)(npc.damage/2), 1, Main.myPlayer, 0, 0);
				}
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.2f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		public override void NPCLoot()
		{
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("MegaTreeBag")));
			}
			else
			{
				int amountToDrop = Main.rand.Next(10,30);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForestEnergy"), amountToDrop);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, (amountToDrop * 3));
			}
		}
	}
}
