using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class DevilScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.magic = true;
			item.mana = 6;
			item.width = 25;
			item.height = 26;
			item.useTime = 15;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 14000;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("scythe");
			item.shootSpeed = 1f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Devil Scythe");
      Tooltip.SetDefault("");
    }

		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.002f;
			sY += (float)Main.rand.Next(-60, 61) * 0.002f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
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
