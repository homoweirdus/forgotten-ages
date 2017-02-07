using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	public class TitanBat : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Titan Bat";
			npc.displayName = "Titan Bat";
			npc.width = 20;
			npc.height = 14;
			npc.damage = 25;
			npc.defense = 10;
			npc.lifeMax = 10;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = 0f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
			aiType = NPCID.GiantBat;
			animationType = NPCID.GiantBat;
		}

		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1f);
			npc.damage = (int)(npc.damage * 1f);
		}
		
		public override bool PreNPCLoot()
		{
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
			}
			
			return false;
		}
	}
}
