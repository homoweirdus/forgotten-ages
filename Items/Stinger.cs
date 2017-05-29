using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Items
{
	public class Stinger : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.Stinger)
			{
				item.ammo = item.type;
				item.shoot = mod.ProjectileType("StingerRocket");
				item.consumable = true;
			}
			
			if (item.type == ItemID.Acorn && Config.VanillaBalance)
			{
				item.thrown = true;
				item.damage = 5;
				item.toolTip = "Right click to throw!";
			}
		}
	}
}