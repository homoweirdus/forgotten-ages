using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class CrazedImpurity : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crazed Impurity";
			item.damage = 140;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Tortures the enemy with agonizing lightning";
			item.useTime = 5;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("lightning");
			item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "impurity", 1);
			recipe.AddIngredient(ItemID.StarWrath, 1);
			recipe.AddIngredient(3458, 30);
			recipe.AddIngredient(3457, 30);
			recipe.AddIngredient(3467, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			if (Main.rand.Next(5) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("IchorLightning"), damage * 2, knockBack, player.whoAmI);
			}
			if (Main.rand.Next(5) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CurseLightning"), damage * 2, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 14);
				Main.dust[dust].scale = 1.5f;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
				Main.dust[dust3].scale = 1.5f;
				Main.dust[dust3].noGravity = true;
			}
			if (Main.rand.Next(5) == 0)
			{
				int dust4 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
				Main.dust[dust4].scale = 1.5f;
				Main.dust[dust4].noGravity = true;
			}
			if (Main.rand.Next(5) == 0)
			{
				int dust5 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
				Main.dust[dust5].scale = 1.5f;
				Main.dust[dust5].noGravity = true;
			}
		}

	}
}
