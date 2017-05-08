using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class EnergyStone : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Energy Stone";
			item.width = 24;
			item.height = 28;
			item.toolTip = "Hold down to ground pound \nHold up to reduce falling speed";
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).GroundPound = true;
		}
	}
}