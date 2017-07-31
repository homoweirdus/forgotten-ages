using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Night
{
	public class TreeMan : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 40;
			npc.damage = 18;
			npc.defense = 10;
			npc.lifeMax = 110;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 508;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ent");
			animationType = NPCID.Zombie;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}
		
		public override void NPCLoot()
		{
			int amountToDrop = Main.rand.Next(3,10);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, amountToDrop);
			if(Main.rand.Next(30) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
			}
		}
	}
}
