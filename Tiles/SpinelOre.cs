using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;

namespace ForgottenMemories.Tiles
{
	public class SpinelOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][57] = true;
            Main.tileMerge[57][Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 203;
			drop = mod.ItemType("Spinel");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Spinel Ore");
			AddMapEntry(new Color(78, 132, 236), name);
			soundType = 21;
			minPick = 35;
			mineResist = 2f;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}