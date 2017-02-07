using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
    public class AccursedBar : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Accursed Bar";
            item.width = 34;
            item.height = 26;
            item.maxStack = 99;
            item.rare = 4;
			item.value = 20000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(522, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 2);
            recipe.AddIngredient(ItemID.ShadowScale, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

        }

    }
}