using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightPistol : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{
			item.name = "Blight Pistol";
			item.damage = 40;
			item.ranged = true;
			item.width = 23;
			item.height = 13;
			item.toolTip = "Creates a blighted ember every 4 uses";
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
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter++;
			if (counter > 3)
			{
				float sX = speedX + (Main.rand.Next(-60, 60) * 0.02f);
				float sY = speedY + (Main.rand.Next(-60, 60) * 0.02f);
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("BlightedEmber"), damage, knockBack, player.whoAmI);
				counter = 0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}