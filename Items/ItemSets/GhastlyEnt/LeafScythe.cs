using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class LeafScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 41;
			item.melee = true;
			item.width = 58;
			item.height = 52;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 27000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Leaf");
			item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaf Scythe");
			Tooltip.SetDefault("Fires a spread of damaging razor leaves");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int projectileAmount = 2;
			for (int k = 0; k < projectileAmount; k++)
			{
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
				
				int f = Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			}
			int a = Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0, 0);
            return false;
        }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
