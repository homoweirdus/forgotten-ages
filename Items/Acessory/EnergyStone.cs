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
			item.toolTip = "Hold down to ground pound \nHold up to reduce falling speed \nIncreases damage by 5%";
			item.value = 10000;
			item.rare = 4;
			item.defense = 5;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).GroundPound = true;
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.thrownDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
		}
	}
}