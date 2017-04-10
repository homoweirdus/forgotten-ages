using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Forbidden Staff";
			item.damage = 110;
			item.magic = true;
			item.width = 94;
			item.height = 94;
			item.toolTip = "Creates a powerful sandnado";
			item.toolTip2 = "Right Clicking will drain magic from enemies";
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 600000;
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			Item.staff[item.type] = true;
			item.autoReuse = true;
			item.mana = 60;
			item.shoot = 656;
			item.noMelee = true;
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
				item.useTime = 2;
				item.useAnimation = 10;
				item.damage = 110;
				item.mana = 0;
			}
			else
			{
				item.useStyle = 5;
				item.useTime = 38;
				item.useAnimation = 38;
				item.damage = 110;
				item.mana = 60;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 mouse = Main.MouseWorld;
				
				Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, mod.ProjectileType("ForbiddenStaff"), 1, 0.1f, player.whoAmI);
			}
			else
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}