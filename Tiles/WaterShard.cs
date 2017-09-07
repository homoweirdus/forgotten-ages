using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
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
			Main.tileShine[mod.TileType("WaterShard")] = 300;
			Main.tileNoFail[mod.TileType("WaterShard")] = true;
			Main.tileLighted[mod.TileType("WaterShard")] = true;
			Main.tileFrameImportant[mod.TileType("WaterShard")] = true;
			Main.tileObsidianKill[mod.TileType("WaterShard")] = true;
			minPick = 65;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Water Shard");
			AddMapEntry(new Color(53, 201, 255), name);
			dustType = 253;
			disableSmartCursor = true;
			drop = mod.ItemType("WaterShard");
		}
		
		public override void DrawEffects(int i, int j, 	SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex )	
		{
			Tile trackTile = Main.tile[i, j];
			int num1 = (int) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 30.0 * (double) Main.gfxQuality);
			int num2 = (int) (50.0 * (1.0 - (double) Main.gfxQuality) + 2.0 * (double) Main.gfxQuality);
			int num3 = 16;
			short num4 = trackTile.frameX;
			short num5 = trackTile.frameY;
			int num6 = 0;
            int num7 = 16;
			SpriteEffects spriteEffects = SpriteEffects.None;
			Vector2 vector2 = Vector2.Zero;
			if ((int) num5 < 36)
			{
				float num8 = vector2.Y + (float)(2 * ((int) num5 == 0).ToDirectionInt());	
				vector2.Y = num8;
			}
			else
			{
				float num8 = vector2.X + (float) (2 * ((int) num5 == 36).ToDirectionInt());
				vector2.X = num8;
			}
			Main.spriteBatch.Draw(Main.tileTexture[mod.TileType("WaterShard")], ((new Vector2((float) (i * 16 - (int) Main.screenPosition.X) - (float) (((double) num3 - 16.0) / 2.0), (float) (j * 16 - (int) Main.screenPosition.Y + num6)))+ vector2), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle((int) num4, (int) num5, num3, num7)), new Microsoft.Xna.Framework.Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 100), 0.0f, new Vector2(), 1f, spriteEffects, 0.0f);
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
}
