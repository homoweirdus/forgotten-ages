using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
	public class GlobalNPC1 : GlobalNPC
	{
		
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.GetModPlayer<MyPlayer>(mod).isGlitch)
			{
				spawnRate = (int)(spawnRate * 50f);
				maxSpawns = (int)(maxSpawns * 50f);
			}
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == 19 && NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("psychic_pistol"));
				nextSlot++;
			}
		}
	}
}
