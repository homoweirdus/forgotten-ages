using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System;
using System.Linq;
using Terraria.ModLoader.IO;
using ForgottenMemories;

namespace ForgottenMemories
{
    public class TGEMWorld : ModWorld
    {
		public static bool Cryotine = false;
		public static bool Gelatine = false;
		public static bool Blight = false;
		public static bool downedGhastlyEnt = false;
		public static bool downedArterius = false;
		public static bool downedTitanRock = false;
		public static bool forestInvasionUp = false;
        public static bool downedForestInvasion = false;
		public static int TremorTime;
		
		public override void Initialize()
        {
			Gelatine = false;
			Blight = false;
			downedArterius = false;
			Cryotine = false;
			downedGhastlyEnt = false;
			TremorTime = 0;
			downedTitanRock = false;
			Main.invasionSize = 0;
            forestInvasionUp = false;
            downedForestInvasion = false;
		}
		
		public override TagCompound Save()
		{
			var downed = new List<string>();
			var ore = new List<string>();
			if (Gelatine) ore.Add("Gelatine");
			if (Cryotine) ore.Add("Cryotine");
			if (Blight) ore.Add("Blight");
			if (downedGhastlyEnt) downed.Add("GhastlyEnt");
			if (downedTitanRock) downed.Add("TitanRock");
			if (downedArterius) downed.Add("Arterius");
			if (downedForestInvasion) downed.Add("forestInvasion");
			
			return new TagCompound {
				{"downed", downed},
				{"ore", ore}
			};;
		}
		
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			var ore = tag.GetList<string>("ore");
			downedGhastlyEnt = downed.Contains("GhastlyEnt");
			downedTitanRock = downed.Contains("TitanRock");
			downedArterius = downed.Contains("Arterius");
			Gelatine = ore.Contains("Gelatine");
			Cryotine = ore.Contains("Cryotine");
			Blight = ore.Contains("Blight");
			downedForestInvasion = downed.Contains("forestInvasion");
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = Gelatine;
			flags[1] = Cryotine;
			flags[2] = downedGhastlyEnt;
			flags[3] = downedTitanRock;
			flags[4] = Blight;
			flags[5] = downedArterius;
			flags[6] = downedForestInvasion;
			writer.Write(flags);
		}
		
		public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
			Gelatine = flags[0];
			Cryotine = flags[1];
			downedGhastlyEnt = flags[2];
			downedTitanRock = flags[3];
			Blight = flags[4];
			downedArterius = flags[5];
            downedForestInvasion = flags[6];
        }
		
		public override void PostUpdate()
        {
            if(forestInvasionUp)
            {
                if(Main.invasionX == (double)Main.spawnTileX)
                {
                    CustomInvasion.CheckCustomInvasionProgress();
                }
                CustomInvasion.UpdateCustomInvasion();
            }
        }
		
        public override void PostWorldGen()
        {
            // Place some items in Marble Chests
            int[] itemsToPlaceInMarbleChests = new int[] { mod.ItemType("MarbleKatana") };
            int itemsToPlaceInMarbleChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 51 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInMarbleChests[itemsToPlaceInMarbleChestsChoice]);
                            itemsToPlaceInMarbleChestsChoice = (itemsToPlaceInMarbleChestsChoice + 1) % itemsToPlaceInMarbleChests.Length;
                            break;
                        }
                    }
                }
            }
			int[] itemsToPlaceInGraniteChests = new int[] { mod.ItemType("GraniteDecimator") };
            int itemsToPlaceInGraniteChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 51 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInGraniteChests[itemsToPlaceInGraniteChestsChoice]);
                            itemsToPlaceInGraniteChestsChoice = (itemsToPlaceInGraniteChestsChoice + 1) % itemsToPlaceInGraniteChests.Length;
                            break;
                        }
                    }
                }
            }
        }
    }
}