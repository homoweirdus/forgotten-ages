using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class DirtDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.crit = -100;
			item.melee = true;
			item.width = 19;
			item.height = 25;
			item.useTime = 5;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0.5;
			item.value = 30000;
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Dirt Dagger");
      Tooltip.SetDefault("An awful start may lead to a great end...");
    }
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Dirt, 15);
			recipe.AddIngredient(ItemID.Stone, 5);
			recipe.AddIngredient(ItemID.Daybloom, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
