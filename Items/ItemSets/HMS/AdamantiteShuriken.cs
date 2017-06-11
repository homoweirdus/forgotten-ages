using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
	public class AdamantiteShurikenP : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.width = 22;
			projectile.height = 22;
			projectile.penetrate = 1;
			aiType = ProjectileID.Shuriken;
			projectile.ignoreWater = true;
			projectile.timeLeft = 6000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Shuriken");
		}


		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(5) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("AdamantiteShuriken"));
			}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 50);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}

	}

	public class AdamantiteShuriken : ModItem
	{

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.damage = 40;
			item.shoot = mod.ProjectileType("AdamantiteShurikenP");

		}
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Adamantite Shuriken");
      Tooltip.SetDefault("");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = Main.rand.Next(2, 4);
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.02f;
				sY += (float)Main.rand.Next(-60, 61) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("AdamantiteShurikenP"), damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}
