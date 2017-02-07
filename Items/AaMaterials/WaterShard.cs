using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class WaterShard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Water Shard";
			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 6000;
			item.rare = 2;
			item.maxStack = 999;
		}
	}
}