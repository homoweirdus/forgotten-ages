using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence {
public class SoaringAxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 5;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 12;
        item.useAnimation = 15;
        item.useStyle = 1;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.axe = 7;
		item.hammer = 35;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Soaring Axe");
      Tooltip.SetDefault("");
    }

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
