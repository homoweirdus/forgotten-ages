using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class Rebalance : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (Config.VanillaBalance)
			{
				if (item.type == ItemID.CrystalVileShard)
				{
					item.damage = 30;
					item.toolTip2 = "Ignores 10 defense";
				}
				
				if (item.type == ItemID.NettleBurst)
				{
					item.damage = 37;
					item.toolTip2 = "Ignores 12 defense";
				}
				
				if (item.type == 3223)
				{
					item.toolTip2 = "All projectiles have 20% chance to inflict confused \nAttacking a confused enemy with a projectile fires a homing bolt towards them";
				}
			}
		}
		
		public override void UpdateAccessory (Item item, Player player, bool hideVisual)
		{
			if (Config.VanillaBalance)
			{
				if (item.type == 3223)
				{
					((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).BoCBuff = true;
				}
			}
		}
		
		public override void HoldItem(Item item, Player player)
        {
            if (Config.VanillaBalance)
            {
				if (item.type == ItemID.CrystalVileShard)
				{
					player.armorPenetration += 10;
				}
				
				if (item.type == ItemID.NettleBurst)
				{
					player.armorPenetration += 12;
				}
            }
        }
	}
}