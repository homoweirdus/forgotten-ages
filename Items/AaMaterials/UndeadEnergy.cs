using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class UndeadEnergy : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Undead Essence";
			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 100;
			item.rare = 0;
			item.scale = 0.75f;
			item.maxStack = 999;
		}
	}
}