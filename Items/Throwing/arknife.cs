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

			item.damage = 19;
			item.thrown = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 0.5f;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("arknife");
			item.shootSpeed = 8;
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
			recipe.AddIngredient(null,"DarkEnergy", 6);
			recipe.AddIngredient(null,"BossEnergy", 6);
			recipe.AddIngredient(null,"SoaringEnergy", 6);
			recipe.AddIngredient(null,"UndeadEnergy", 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
