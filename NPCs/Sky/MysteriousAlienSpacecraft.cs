using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Sky
{
	public class MysteriousAlienSpacecraft : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "MysteriousAlienSpacecraft";
			npc.displayName = "Mysterious Alien Spacecraft";
			npc.width = 48;
			npc.height = 36;
			npc.damage = 30;
			npc.defense = 16;
			npc.lifeMax = 130;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 70f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			Main.npcFrameCount[npc.type] = 4;
			aiType = -1;
			animationType = 93;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSkyHeight ? 0.2f : 0f;
		}
		
					public override void NPCLoot()
	{
			if(Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LightningPistol"));
			}
			
	}
	
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
	{
		npc.lifeMax = (int)(npc.lifeMax * 1f);
		npc.damage = (int)(npc.damage * 1f);
	}
	
	}
}
