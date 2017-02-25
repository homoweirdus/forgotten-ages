using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class TreasureBagDrops : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == 3318 && Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SlimeRod"), 1);
			}
			
			if (context == "bossBag" && arg == 3319 && Main.rand.Next(1) == 0)
			{
				int amountToDrop = Main.rand.Next(36,42);
				player.QuickSpawnItem(mod.ItemType("WideLens"), amountToDrop);
			}
			
			if (context == "bossBag" && arg == 3324 && Main.rand.Next(1) == 0)
			{
				int amountToDrop = Main.rand.Next(10,15);
				player.QuickSpawnItem(mod.ItemType("BrassAlloy"), amountToDrop);
				
				if (Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MinerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NinjaEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BerserkerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinEmblem"), 1); 
				}
			}
		}
	}
}