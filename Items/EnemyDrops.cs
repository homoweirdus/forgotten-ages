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
			
			if (npc.type == NPCID.AngryNimbus && Main.rand.Next(25) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LightningDagger"), 1); 
			}
			
			if (npc.type == 204 && Main.rand.Next(40) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JungleSlimePendant"), 1); 
			}
			
			if (npc.type == 147 && Main.rand.Next(40) == 0 || npc.type == 184 && Main.rand.Next(40) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSlimeNecklace"), 1); 
			}
			
			if (npc.type == 533 && Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertStaff"), 1); 
			}
			
			if (npc.type == 471)
			{
				int amountToDrop = Main.rand.Next(9,14);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameEmber"), amountToDrop); 
			}
			
			if (Main.bloodMoon && Main.rand.Next(3) == 0)
			{
				int amountToDrop = Main.rand.Next(8,14);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDagger"), amountToDrop); 
			}
			
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
			{
				int amountToDrop = Main.rand.Next(10,15);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassAlloy"), amountToDrop); 
				
				if (Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MinerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NinjaEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BerserkerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinEmblem"), 1); 
				}
			}
			
			if (npc.type == 4 && !Main.expertMode)
			{
				int amountToDrop = Main.rand.Next(20,28);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OpticBar"), amountToDrop); 
			}
			
			if (npc.type == 439)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexSphere"), 1); 
			}
			
			if (npc.type == NPCID.KingSlime && TGEMWorld.Gelatine == false)
			{
				Main.NewText("Gelatine grows in the underground!", 0, 29, 255);
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 30E-05); k++)
				{
					WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .5f)), (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), (ushort)mod.TileType("GelatineOre"));
					
					
				}
				TGEMWorld.Gelatine = true;
			}
			
			if (npc.type == 4 && TGEMWorld.Cryotine == false)
			{
				Main.NewText("An eerie presence is felt coming from the forests...", 53, 140, 51);
				Main.NewText("Ice crystallizes in the underground snow!", 36, 242, 242);
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 64E-05); k++)
				{
					int positionX = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
					int positionY = WorldGen.genRand.Next(200, Main.maxTilesY - 200);
					Tile tile = Main.tile[positionX, positionY];
					if (tile.type == 147 || tile.type == 161)
					{
						WorldGen.OreRunner(positionX, positionY, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), (ushort)mod.TileType("CryotineOre"));
					}
				}
				TGEMWorld.Cryotine = true;
			}
			
			if (npc.type == 134 && TGEMWorld.Blight == false || npc.type == 127 && TGEMWorld.Blight == false || npc.type == 125 && TGEMWorld.Blight == false && !NPC.AnyNPCs(126) || npc.type == 126 && TGEMWorld.Blight == false && !NPC.AnyNPCs(125))
			{
				Main.NewText("A malevolent force seeps into the crimtane and corrupt stone...", 150, 31, 242);
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 64E-05); k++)
				{
					int positionX = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
					int positionY =  WorldGen.genRand.Next(200, Main.maxTilesY - 200);
					Tile tile = Main.tile[positionX, positionY];
					if (tile.type == 203 || tile.type == 204 || tile.type == 22 || tile.type == 25 || tile.type == 112 || tile.type == 398 || tile.type == 400 || tile.type == 399 || tile.type == 401 || tile.type == 234 || tile.type == 163 || tile.type == 200)
					{
						WorldGen.OreRunner(positionX, positionY, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), (ushort)mod.TileType("BlightOre"));
					}
				}
				TGEMWorld.Blight = true;
			}
			
			if (Main.invasionType == 4 && Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MartianYoyo"), 1); 
			}

			if (npc.type == 62 && NPC.downedBoss1 && Main.rand.Next(3) == 0 || npc.type == 24 && NPC.downedBoss1 && Main.rand.Next(3) == 0 || npc.type == 66 && NPC.downedBoss1 && Main.rand.Next(3) == 0 || npc.type == 60 && NPC.downedBoss1 && Main.rand.Next(3) == 0 || npc.type == 59 && NPC.downedBoss1 && Main.rand.Next(3) == 0 || npc.type == 39 && NPC.downedBoss1 && Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DevilFlame"), 1); 
			}
			
			if (npc.type == 156 || npc.type == 151)
			{
				int amountToDrop = Main.rand.Next(1,3);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DevilFlame"), amountToDrop); 
			}
			
			if (npc.type == 65 && Main.rand.Next(50) == 0 || npc.type == 64 && Main.rand.Next(50) == 0 || npc.type == 67 && Main.rand.Next(50) == 0 || npc.type == 221 && Main.rand.Next(25) == 0 || npc.type == 220 && Main.rand.Next(15) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pearl"), 1); 
			}
		}
	}
}