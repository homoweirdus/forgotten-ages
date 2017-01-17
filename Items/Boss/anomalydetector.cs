using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss {
public class anomalydetector : ModItem
{
public override void SetDefaults()
    {
        item.name = "Ancient Signal";
        item.width = 28;
        item.height = 32;
        item.maxStack = 20;
        item.toolTip = "Signals something ancient";
        item.rare = 1;
        item.useAnimation = 45;
        item.useTime = 45;
        item.useStyle = 4;
        item.consumable = true;
    }
	
	public override bool CanUseItem(Player player)
	{
		return !NPC.AnyNPCs(mod.NPCType("TitanRock"));
	}
	
	public override bool UseItem(Player player)
    {
        NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TitanRock"));
        Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
        return true;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Ruby, 1);
		recipe.AddIngredient(ItemID.IronBar, 5);
		recipe.AddIngredient(ItemID.MeteoriteBar, 5);
		recipe.AddTile(18);
        recipe.SetResult(this);
        recipe.AddRecipe();
		
		recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Ruby, 1);
		recipe.AddIngredient(ItemID.LeadBar, 5);
		recipe.AddIngredient(ItemID.MeteoriteBar, 5);
		recipe.AddTile(18);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}