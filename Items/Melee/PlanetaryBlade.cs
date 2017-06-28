using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ForgottenMemories.Items.Melee
{
	public class PlanetaryBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 100;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 14;
			item.useAnimation = 7;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PlanetaryWave");
			item.shootSpeed = 20;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Planetary Blade");
      Tooltip.SetDefault("Fires seeds and a gigantic wave");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ItemID.Seedler, 1);
			recipe.AddIngredient(null, "ForestEnergy", 8);
			recipe.AddIngredient(3458, 30);
			recipe.AddIngredient(3456, 30);
			recipe.AddIngredient(3467, 10);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, 483, damage / 2, knockBack, player.whoAmI);
			
			float sX2 = speedX;
			float sY2 = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX2, sY2, 483, damage / 2, knockBack, player.whoAmI);
			
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI);
			
			return false;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 2);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(4) == 0)
			{
				int dust5 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
				Main.dust[dust5].scale = 2f;
				Main.dust[dust5].noGravity = true;
			}
			if (Main.rand.Next(4) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 128);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}
}
