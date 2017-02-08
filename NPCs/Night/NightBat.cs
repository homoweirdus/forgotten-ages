using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Night
{
	public class NightBat : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Night Bat";
			npc.displayName = "Night Bat";
			npc.width = 24;
			npc.height = 18;
			npc.damage = 15;
			npc.defense = 10;
			npc.lifeMax = 25;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
			aiType = NPCID.GiantBat;
			animationType = NPCID.GiantBat;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (tile == 2) && !Main.bloodMoon && spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.1f : 0f;
		}
		
	public override void NPCLoot()
	{
	if(Main.rand.Next(5) == 0)
    {
        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoaringEnergy"));
    }
		if(Main.rand.Next(20) == 0)
    {
        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkEnergy"));
    }
	}
	
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
	{
		npc.lifeMax = (int)(npc.lifeMax * 1f);
		npc.damage = (int)(npc.damage * 1f);
	}
	
	}
}
