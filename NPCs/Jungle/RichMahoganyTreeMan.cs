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
			npc.lifeMax = 130;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 508;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mahogany Ent");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
			animationType = NPCID.Zombie;
		}
		
		public override void NPCLoot()
		{
			int amountToDrop = Main.rand.Next(3,10);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichMahogany, amountToDrop);
			if(Main.rand.Next(30) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
			}
		}
	
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1.3f);
			npc.damage = (int)(npc.damage * 1f);
		}
	}
}
