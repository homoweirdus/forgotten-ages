using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs
{
	public class ForgottenNPC : GlobalNPC
	{
		public override void NPCLoot (NPC npc)
		{
		
			if (Main.rand.Next(1) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("soul"));
			}
		}
	}
}