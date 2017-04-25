using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class fuckbow : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{
			item.name = "Blighted Drake";
			item.damage = 55;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 500000;
			item.rare = 8;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = mod.ProjectileType("BlightArrow");
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter++;
			
			if (counter >= 4)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BlightDragon"), damage, knockBack, player.whoAmI);
				counter = 0;
			}
			
			else for (int i = 0; i < 2; i++)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.02f;
				sY += (float)Main.rand.Next(-60, 61) * 0.02f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, ProjectileID.CursedArrow, damage, knockBack, player.whoAmI);
				Main.projectile[p].noDropItem = true;
			}
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3854, 1);
			recipe.AddIngredient(ItemID.CursedFlame, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.BeetleHusk, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}