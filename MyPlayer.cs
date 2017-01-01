using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
    public class MyPlayer : ModPlayer
    {
		public override void SetupStartInventory(IList<Item> items)
		{
			items.Clear();
			Item item = new Item();
			if (Main.rand.Next(10) == 0)
			{
				item.SetDefaults(mod.ItemType("OldBlade"));
			}
			else
			{
				item.SetDefaults(3507);
			}
			items.Add(item);
			
			
			Item item2 = new Item();
			if (Main.rand.Next(10) == 0)
			{
				item2.SetDefaults(mod.ItemType("OldPick"));
			}
			else
			{
				item2.SetDefaults(3509);
			}
			items.Add(item2);
			
			
			Item item3 = new Item();
			if (Main.rand.Next(10) == 0)
			{
				item3.SetDefaults(mod.ItemType("OldAxe"));
			}
			else
			{
				item3.SetDefaults(3506);
			}
			items.Add(item3);
		}
			
    }
}