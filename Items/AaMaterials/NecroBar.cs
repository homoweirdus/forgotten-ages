using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class NecroBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Necro Bar";
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 20000;
			item.rare = 3;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(521, 1);
            recipe.AddTile(26);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}