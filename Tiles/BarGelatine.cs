using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
	public class BarGelatine : ModTile
	{
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            //TileObjectData.addTile(Type);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            Main.tileSolidTop[Type] = true;   
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;      
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("GelatineBar");
			AddMapEntry(new Color(0, 0, 255), name);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                8,
                8
            };

            TileObjectData.addTile(Type);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("GelatineBar"));
		}
	}

	
}
