using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class NecroDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.thrown = true;
			item.width = 32;
			item.height = 36;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 60000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecroDagger");
			item.shootSpeed = 13;
			item.noMelee = true;
			item.noUseGraphic = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Necro Dagger");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 35);
			recipe.AddIngredient(null, "DarkEnergy", 3);
			recipe.AddIngredient(ItemID.Cobweb, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
