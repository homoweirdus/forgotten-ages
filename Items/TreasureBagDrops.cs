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
		}
	}
}