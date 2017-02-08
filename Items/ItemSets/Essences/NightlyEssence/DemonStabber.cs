using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence {
public class DemonStabber : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Demon Stabber";
        item.damage = 12;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 8;
        item.useAnimation = 8;
        item.useStyle = 3;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.toolTip = "Useful for stabbing enemies enemies, including demons";
		item.useTurn = true;
    }
	
			public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 10);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}