using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Zouls
{
	public class soul : ModItem
	{
		
		public override void SetDefaults()
		{
			item.name = "Lost Soul";
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			item.toolTip = "'Used to create class souls'";
			item.value = 1000;
			item.rare = 3;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(5, 4);
		}

		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange *= 3;
		}
	}

	public class SoulGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.lifeMax >= 50 && Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("soul"), 1);
			}
		}
	}
}
