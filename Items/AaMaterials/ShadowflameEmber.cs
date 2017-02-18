using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class ShadowflameEmber : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shadowflame Ember";
			item.width = 7;
			item.height = 8;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 9);
            recipe.AddIngredient(null, "ShadowflameEmber", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(3052, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 9);
            recipe.AddIngredient(null, "ShadowflameEmber", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(3054, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 9);
            recipe.AddIngredient(null, "ShadowflameEmber", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(3053, 1);
            recipe.AddRecipe();
        }
	}
}