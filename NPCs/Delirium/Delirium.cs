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
		
        public override void SetDefaults()
        {
            npc.name = "Delirium";
            npc.displayName = "Delirium";
            npc.aiStyle = -1;
            npc.lifeMax = 500000;
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
			
			if (timer == 400)
			{
			
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
