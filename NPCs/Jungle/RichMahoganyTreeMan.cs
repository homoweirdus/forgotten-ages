using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Jungle
{
	public class RichMahoganyTreeMan : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 40;
			npc.damage = 20;
			npc.defense = 10;
			npc.lifeMax = 70;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Mahogany Tree Man");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
			animationType = NPCID.Zombie;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
				int y = spawnInfo.spawnTileY;
				int tile = (int)Main.tile[x, y].type;
					return !Main.bloodMoon && spawnInfo.player.ZoneJungle && (tile == 60) && spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.2f : 0f;
		}
		
			public override void NPCLoot()
	{
			int amountToDrop = Main.rand.Next(3,10);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichMahogany, amountToDrop);
					if(Main.rand.Next(30) == 0)
    {
        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
    }
	
		if (NPC.downedBoss1 == true);
			{
				if(Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientLog"), 1);
				}
			}
	}
	
			public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
	{
		npc.lifeMax = (int)(npc.lifeMax * 1f);
		npc.damage = (int)(npc.damage * 1f);
	}
	}
}
