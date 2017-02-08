using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence {
public class CrimtaneStabber : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Crimtane Stabber";
        item.damage = 13;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 7;
        item.useAnimation = 7;
        item.useStyle = 3;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.toolTip = "Stabs extremely fast";
		item.useTurn = true;
    }
	
			public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 10);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}