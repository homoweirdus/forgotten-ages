using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class Woodlouse : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 18;
			npc.damage = 50;
			npc.defense = 8;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 508;
		}
		
		public override void AI()
        {
			Player player = Main.player[npc.target];
			
			if (npc.position.X > player.position.X)
			{
				npc.spriteDirection = -1;
			}
			if (npc.position.X < player.position.X)
			{
				npc.spriteDirection = 1;
			}
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Woodlouse");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
			animationType = NPCID.Zombie;
		}
	}
}
