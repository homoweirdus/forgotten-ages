using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Snow
{
	public class PineFlyer : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Pine Flyer";
			npc.displayName = "Pine Flyer";
			npc.width = 66;
			npc.height = 42;
			npc.damage = 25;
			npc.defense = 10;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath33;
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
			return (tile == 147) && !Main.bloodMoon && spawnInfo.player.ZoneSnow && spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.1f : 0f;
		}
		
		public override void NPCLoot()
		{
			if(Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PineStaff"));
			}
			
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 7);      
				Main.dust[dust].scale = 1.5f;
			}
			
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 2);      
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1f);
			npc.damage = (int)(npc.damage * 1f);
		}
		
	}
}
