using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class Pearl : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

		AddTooltip("Taking damage when under half of your max health will restore even more health");
		AddTooltip("'The ocean protects you'");
        item.value = 100000;
        item.rare = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pearl");
      Tooltip.SetDefault("Taking over 10 damage has a 1/2 chance to restore 10 health");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).pearl = true;
	}
	
	public override bool CanEquipAccessory(Player player, int slot)
		{
			if (((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).pearl2 == true)
			{
				return false;
			}
			
			else
			{
				return true;
			}
		}
}}
