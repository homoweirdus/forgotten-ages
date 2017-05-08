using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss {
public class AncientLog : ModItem
{
	public override void SetDefaults()
		{
			item.name = "Ancient Log";
			item.width = 28;
			item.height = 32;
			item.maxStack = 20;
			item.toolTip = "Summons an Ancient Guardian of the forest...";
			item.rare = 0;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("GhastlyEnt"));
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("GhastlyEnt"));
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 8);
			recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();	
		}
	}
}