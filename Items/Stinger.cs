using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
		}
	}
}