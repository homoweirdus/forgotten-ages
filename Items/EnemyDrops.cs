using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class CrystalDrop : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			
			if (npc.type == NPCID.KingSlime && !Main.expertMode && Main.rand.Next(8) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeRod"), 1); 
			}
			
			if (npc.type == 32 && Main.rand.Next(3) == 0)
			{
				int amountToDrop = Main.rand.Next(1,2);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaterShard"), amountToDrop); 
			}
			
			if (npc.type == 489 && Main.rand.Next(40) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodHeart"), 1); 
			}
			
			if (npc.type == 204 && Main.rand.Next(40) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JungleSlimePendant"), 1); 
			}
			
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
			{
				int amountToDrop = Main.rand.Next(10,15);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassAlloy"), amountToDrop); 
			}
			
			if (npc.type == 4 && !Main.expertMode)
			{
				int amountToDrop = Main.rand.Next(36,42);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WideLens"), amountToDrop); 
			}
			
			if (npc.type == NPCID.KingSlime)
			{
				Main.NewText("Gelatine grows in the underground!", 0, 29, 255);
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
				{
					WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .5f)), (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)mod.TileType("GelatineOre"));
					
					
				}
			}
		}
	}
}