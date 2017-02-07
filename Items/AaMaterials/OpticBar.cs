using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class OpticBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Optic Bar";
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(38, 1);
            recipe.AddIngredient(null, "WideLens", 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}