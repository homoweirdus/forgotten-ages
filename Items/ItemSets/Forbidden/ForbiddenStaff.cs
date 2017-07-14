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

			item.damage = 47;
			item.magic = true;
			item.width = 94;
			item.height = 94;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			Item.staff[item.type] = true;
			item.autoReuse = true;
			item.mana = 15;
			item.shoot = mod.ProjectileType("ForbiddenStaffProj");
			item.noMelee = true;
			item.shootSpeed = 7f;
		}



    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Staff");
      Tooltip.SetDefault("Fires an exploding forbidden bolt");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
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
