using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class Autoswing : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.NightsEdge)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.DarkLance)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.CobaltNaginata)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.PalladiumPike)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.MythrilHalberd)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.OrichalcumHalberd)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.AdamantiteGlaive)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.Gungnir)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.ObsidianSwordfish)
			{
				item.autoReuse = true;
			}
			
			if (item.type == ItemID.NorthPole)
			{
				item.autoReuse = true;
			}
		}
		
		public override bool CanUseItem(Item item, Player player)
        {
			if (item.type == ItemID.DarkLance)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 46)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.CobaltNaginata)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 97)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.PalladiumPike)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 212)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.MythrilHalberd)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 64)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.OrichalcumHalberd)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 218)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.AdamantiteGlaive)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 66)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.Gungnir)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 105)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.ObsidianSwordfish)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 367)
					{
						return false;
					}
				}
				return true;
			}
			
			if (item.type == ItemID.NorthPole)
			{
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == 342)
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}
	}
}