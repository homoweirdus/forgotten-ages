using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class BrassAlloy : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Brass Alloy";
			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 25000;
			item.rare = 3;
			item.scale = 0.75f;
			item.maxStack = 999;
		}
	}
}