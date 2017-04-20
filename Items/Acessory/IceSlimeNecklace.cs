using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
 {
public class IceSlimeNecklace : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Frost Necklace";
        item.width = 24;
        item.height = 28;
        item.toolTip = "Getting hit releases a slime guard to protect you";
        item.value = 50000;
        item.rare = 2;
        item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).frostguard = true;
	}
}
}