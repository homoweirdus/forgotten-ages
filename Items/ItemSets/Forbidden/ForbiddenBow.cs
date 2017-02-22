using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Forbidden Bow";
			item.damage = 70;
			item.ranged = true;
			item.width = 40;
			item.height = 100;
			item.toolTip = "Right Clicking will fire a barrage of arrows";
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 600000;
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = 40;
			item.shoot = 3;
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(3261, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 5;
				item.useTime = 36;
				item.useAnimation = 36;
				item.damage = 14;
			}
			else
			{
				item.useStyle = 5;
				item.useTime = 16;
				item.useAnimation = 16;
				item.damage = 60;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				int amountOfProjectiles = Main.rand.Next(10, 20);
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float sX = speedX;
						float sY = speedY;
						sX += (float)Main.rand.Next(-120, 120) * 0.02f;
						sY += (float)Main.rand.Next(-120, 120) * 0.02f;
						Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
					}
			}
			else
			{
				for (int i = 0; i < 2; ++i)
					{
						float sX = speedX;
						float sY = speedY;
						sX += (float)Main.rand.Next(-60, 60) * 0.02f;
						sY += (float)Main.rand.Next(-60, 60) * 0.02f;
						Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
					}
			}
			return false;
		}
	}
}