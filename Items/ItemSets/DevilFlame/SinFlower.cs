using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.DevilFlame
{
	public class SinFlower : ModItem
	{
		float memer = 0f;
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 20;
			item.useTime = 20;
			item.shootSpeed = 14f;
			item.knockBack = 2f;
			item.width = 16;
			item.height = 16;
			item.damage = 26;
			item.UseSound = SoundID.Item13;
			item.shoot = mod.ProjectileType("SinFlower");
			item.mana = 10;
			item.value = 10000;
            item.rare = 2;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.magic = true;
			item.channel = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sin Flower");
      Tooltip.SetDefault("");
    }
	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DevilFlame", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
