using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class arknife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.thrown = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("arknife");
			item.shootSpeed = 10;
			item.noMelee = true;
			item.noUseGraphic = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ark Dagger");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ItemID.ThrowingKnife, 500);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
