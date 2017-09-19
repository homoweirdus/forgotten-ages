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
            npc.lifeMax = 35000;
            npc.damage = 60;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 202;
            npc.height = 310;
            npc.value = 150000;
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
            music = 12;
			npc.npcSlots = 5;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
			{
				npc.lifeMax = 50000 + ((numPlayers) * 20000);
				npc.damage = 90;
			}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghastly Ent");
			Main.npcFrameCount[npc.type] = 5;
		}

        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			npc.ai[0]++;
			
			if (npc.life > (int)(npc.lifeMax/2) && !Main.expertMode || npc.life > (int)(npc.lifeMax * 0.66) && Main.expertMode)
			{
				Phase1(player);
			}
			else if (!Main.expertMode || npc.life > (int)(npc.lifeMax/3) && Main.expertMode)
			{
				Phase2(player);
			}
			else
			{
				Phase3(player);
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
		
		public static void Phase1(Player player)
		{
			
		}
		
		public static void Phase2(Player player)
		{
			
		}
		
		public static void Phase3(Player player)
		{
			
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
				TGEMWorld.TryForBossMask(npc.Center, npc.type);
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
				}
			}
        }
    }
