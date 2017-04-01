using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss
{
	public class TitanRockBag : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Treasure Bag";
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.toolTip = "Right click to open";
			item.expert = true;
			bossBagNPC = mod.NPCType("TitanRock");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			int amountToDrop = Main.rand.Next(5,15);
			player.QuickSpawnItem(mod.ItemType("ProtectionCrystal"), amountToDrop);
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("LaserbeamStaff"), 1);
			}
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BeamSlicer"), 1);
			}
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("LaserbladeKatana"), 1);
			}
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Needler"), 1);
			}
			player.QuickSpawnItem(mod.ItemType("EnergyStone"), 1);
		}
	}
}