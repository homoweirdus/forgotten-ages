using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Corruption
{
	public class Deathhopper : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 48;
			npc.height = 36;
			npc.damage = 26;
			npc.defense = 4;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 50);
			npc.knockBackResist = 1f;
			npc.aiStyle = 1;
			aiType = NPCID.BlueSlime;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deathweed Hopper");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
			animationType = NPCID.BlueSlime;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneCorrupt ? 0.08f : 0f;
			return spawnInfo.player.ZoneCrimson ? 0.08f : 0f;
		}
		
					public override void NPCLoot()
					{
						int amountToDrop = Main.rand.Next(1,5);
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, amountToDrop);
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Deathweed, amountToDrop);
						if(Main.rand.Next(40) == 0)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DeathweedStaff"));
						}
						
						if(Main.rand.Next(40) == 0)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DeathweedDecimator"));
						}		
					}
	
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
	{
		npc.lifeMax = (int)(npc.lifeMax * 1f);
		npc.damage = (int)(npc.damage * 1f);
	}
	
	}
}
