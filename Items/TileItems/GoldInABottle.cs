using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.TileItems
{
	public class GoldInABottle : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gold in a bottle";
			item.width = 10;
			item.height = 12;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("GoldBottleTile");
			item.value = 1000;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(13, 1);
            recipe.AddIngredient(31, 1);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(702, 1);
            recipe2.AddIngredient(31, 1);
            recipe2.AddTile(16);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }

    }
}