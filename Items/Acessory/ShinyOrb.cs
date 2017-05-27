using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class ShinyOrb : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shiny Orb";
			item.width = 22;
			item.height = 22;
			AddTooltip("Standing still increases life regen, summons homing energy over time");
			item.value = 100000;
			item.expert = true;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).ShinyOrbSpawn();
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).ShinyOrbHeal();
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SporeSac, 1);
			recipe.AddIngredient(ItemID.ShinyStone, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (player.shinyStone == true || player.sporeSac == true)
			{
				return false;
			}
			
			else
			{
				return true;
			}
		}
	}
}