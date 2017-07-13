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

			item.damage = 31;
			item.ranged = true;
			item.width = 40;
			item.height = 100;

			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = 40;
			item.shoot = mod.ProjectileType("ForbiddenArrow");
			item.noMelee = true;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Bow");
      Tooltip.SetDefault("Fires 3 forbidden arrows");
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
				int amountOfProjectiles = 3;
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float sX = speedX;
						float sY = speedY;
						sX += (float)Main.rand.Next(-120, 120) * 0.02f;
						sY += (float)Main.rand.Next(-120, 120) * 0.02f;
						int homo = Main.rand.Next(-50, 50);
						int gay = Main.rand.Next(-50, 50);
						int po = Projectile.NewProjectile(position.X + homo, position.Y + gay, sX, sY, mod.ProjectileType("ForbiddenArrow"), damage, knockBack, player.whoAmI);
						Main.projectile[po].tileCollide = false;
						Main.projectile[po].noDropItem = true;
					}
			return false;
		}
	}
}
