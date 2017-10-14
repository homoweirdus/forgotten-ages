using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightPistol : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{

			item.damage = 40;
			item.ranged = true;
			item.width = 23;
			item.height = 13;

			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.autoReuse = true;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 250000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.shoot = 10;
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blight Pistol");
		  Tooltip.SetDefault("Critical hits cause you to fire a beam of high-pressure blighted fire");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile projectile = Main.projectile[Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, 0f)];
			projectile.GetGlobalProjectile<Info>(mod).Blight = true;
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OceanPistol", 12);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
