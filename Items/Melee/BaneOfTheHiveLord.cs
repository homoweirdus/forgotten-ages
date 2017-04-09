using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class BaneOfTheHiveLord : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Bane of the Hive Lord";
			item.damage = 56;
			item.melee = true;
			item.width = 22;
			item.height = 25;
			AddTooltip("Striking an enemy with the blade will unleash bees and wasps");
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 270000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 5f;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 16);
			recipe.AddIngredient(ItemID.BeeKeeper, 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			for (int i = 0; i <= 2; i++)
            {
				float sX = 2f;
				float sY = 2f;
				sX += (float)Main.rand.Next(-60, 61) * 0.2f;
				sY += (float)Main.rand.Next(-60, 61) * 0.2f;
                Projectile.NewProjectile(target.Center.X, target.Center.Y, sX, sY, ProjectileID.Bee, damage, knockback, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, -sX, -sY, ProjectileID.Wasp, damage, knockback, player.whoAmI, 0f, 0f);
            }
        }
	}
}
