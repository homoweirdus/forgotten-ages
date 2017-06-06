using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.OreArrows
{
	public class LeadArrow : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 28;
            item.value = 30;
            item.rare = 2;

            item.maxStack = 999;

            item.damage = 6;
			item.knockBack = 2f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("LeadArrow");
            item.shootSpeed = 1.1f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lead Arrow");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 1);
            recipe.AddIngredient(40, 30);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
		}
	}
}
