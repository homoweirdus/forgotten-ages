using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmorockGreaves : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Cosmic Greaves";
			item.width = 18;
			item.height = 18;
			AddTooltip("Increased Life Regen");
			item.value = 10000;
			item.rare = 4;
			item.defense = 12;
			item.lifeRegen = 2;
		}
	}
}