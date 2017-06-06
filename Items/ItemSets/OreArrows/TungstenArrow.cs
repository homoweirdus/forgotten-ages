using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.OreArrows
{
	public class TungstenArrow : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 28;
            item.value = 60;

            item.rare = 2;

            item.maxStack = 999;

            item.damage = 5;
			item.knockBack = 2f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("TungstenArrow");
            item.shootSpeed = 1.33f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Tungsten Arrow");
      Tooltip.SetDefault("Can pierce 2 times");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 1);
            recipe.AddIngredient(40, 30);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
		}
	}
}
