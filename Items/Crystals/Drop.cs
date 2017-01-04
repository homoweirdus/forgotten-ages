using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Crystals
{
	public class Drop : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == 3318)
			{
				player.QuickSpawnItem(mod.ItemType("ChampionCrystal"), Main.rand.Next(5, 15));
			}
			if (context == "bossBag" && arg == 3319)
			{
				player.QuickSpawnItem(mod.ItemType("VisionCrystal"), Main.rand.Next(5, 15));
			}
			if (context == "bossBag" && arg == 3320)
			{
				player.QuickSpawnItem(mod.ItemType("DominationCrystal"), Main.rand.Next(5, 15));
			}
			if (context == "bossBag" && arg == 3321)
			{
				player.QuickSpawnItem(mod.ItemType("ConfusionCrystal"), Main.rand.Next(5, 15));
			}
			if (context == "bossBag" && arg == 3322)
			{
				player.QuickSpawnItem(mod.ItemType("InfestationCrystal"), Main.rand.Next(5, 15));
			}
			if (context == "bossBag" && arg == 3323)
			{
				player.QuickSpawnItem(mod.ItemType("ExterminationCrystal"), Main.rand.Next(5, 15));
			}
			if (context == "bossBag" && arg == 3324)
			{
				player.QuickSpawnItem(mod.ItemType("OblivionCrystal"), Main.rand.Next(5, 15));
			}
		}
	}
}