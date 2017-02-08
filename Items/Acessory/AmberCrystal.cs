using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class AmberCrystal : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Amber Crystal";
        item.width = 24;
        item.height = 28;
        item.toolTip = "Summon attacks have a chance to create balls of sap";
		item.toolTip2 = "A powerful crystal made from the powerful sap of the ghastly ent";
        item.value = 50000;
        item.rare = 2;
        item.accessory = true;
		item.expert = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).sapBall = true;
	}
}}