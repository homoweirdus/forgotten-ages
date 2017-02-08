using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class FirestormBottle : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Firestorm in a Bottle";
        item.width = 24;
        item.height = 28;
        item.toolTip = "Enhances your jump, leaving behind fire";
        item.value = 150000;
        item.rare = 2;
        item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).firestorm = true;
		player.jumpSpeedBoost = 2f;
	}
}}