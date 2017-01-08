using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	public class SpikeTitan : ModNPC
	{
		int timer = 0;
		public override void SetDefaults()
		{
			npc.name = "Spiked Titan";
			npc.displayName = "Spiked Titan";
			npc.width = 64;
			npc.height = 64;
			npc.damage = 25;
			npc.defense = 10;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
			animationType = NPCID.GiantBat;
			npc.lavaImmune = true;
			aiType = NPCID.GiantBat;
		}

	
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
	{
		npc.lifeMax = (int)(npc.lifeMax * 1f);
		npc.damage = (int)(npc.damage * 1f);
	}
	
	public override bool PreNPCLoot()
		{
			for (int i = 0; i < 30; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
				Main.dust[dust].scale = 1.5f;
			}
			
			return false;
		}
		
		public override void AI()
		{
			timer++;
			if (timer == 60)
			{
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
			direction.Normalize();
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 4f, direction.Y * 4f, 84, 20, 1, Main.myPlayer, 0, 0);
			timer = 0;
			}
		}
	
	}
}
