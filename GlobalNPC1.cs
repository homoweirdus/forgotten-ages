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
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot) // add items to npc shops
		{
			if (type == 19) // arms dealer
			{
				if (NPC.downedBoss2) // check if EoW/BoC is defeated
				{
					shop.item[nextSlot].SetDefaults(mod.ItemType("psychic_pistol")); // sell psychic pistol
					nextSlot++;
				}
				for (int i = 0; i < 200; i++) // loop through 200 players
				{
					Player player = Main.player[i];
					if (player.HasItem(mod.ItemType("LightningPistol")) || player.HasItem(mod.ItemType("LaserCannon")) || player.HasItem(mod.ItemType("LightningChaingun")))
					{ // check if the player has a lightning pistol or upgrade in their inventory
						shop.item[nextSlot].SetDefaults(mod.ItemType("LightningArrow")); //sell the lightning arrow
						nextSlot++;
					}
				}
			}
		}
	}
}
