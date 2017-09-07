using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace ForgottenMemories.Tiles
{
	public class WaterShard : ModTile
	{
		public override void SetDefaults()
		{
			tile.CloneDefaults(129);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Water Shard");
			AddMapEntry(new Color(53, 201, 255), name);
			dustType = 253;
			disableSmartCursor = true;
			drop = mod.ItemType("WaterShard");
		}
	}

	/*public class WaterShardSpawn : ModWorld
	{
		public override void PostUpdate()
		{
			if (!NPC.downedBoss3)
				return;
			float num3 = (float) (Main.maxTilesX * Main.maxTilesY) * (3E-05f * (float) Main.worldRate);
			for (int index1 = 0; (double) index1 < (double) num3; ++index1)
			{
				int index2 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
				int index3 = WorldGen.genRand.Next(10, (int) Main.worldSurface - 1);
			}
		}
	}*/
}
