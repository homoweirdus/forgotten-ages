using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class Finale : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Finale";
			item.damage = 360;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			AddTooltip("Releases a barrage of splitting bolts");
			AddTooltip("Right-Clicking creates shockwaves in all directions and an explosive blade");
			AddTooltip("Striking an enemy with the blade heals you and greatly reduces enemy defense");
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 2000000;
			item.rare = 11;
			item.expert = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FinaleBlade");
			item.shootSpeed = 12;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 63);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 10f, 0f, mod.ProjectileType("FinalePlanet"), damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, -10f, 0f, mod.ProjectileType("FinalePlanet"), damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 0f, -10f, mod.ProjectileType("FinalePlanet"), damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 0f, 10f, mod.ProjectileType("FinalePlanet"), damage, knockBack, player.whoAmI);
			}
			else
			{
				int amountOfProjectiles = Main.rand.Next(4, 6);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = speedX;
					float sY = speedY;
					sX += (float)Main.rand.Next(-60, 61) * 0.02f;
					sY += (float)Main.rand.Next(-60, 61) * 0.02f;
					Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("FinalePure"), damage/2, knockBack, player.whoAmI);
				}
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"Climax", 1);
			recipe.AddIngredient(null,"PlanetaryBlade", 1);
			recipe.AddIngredient(null,"CrazedImpurity", 1);
			recipe.AddIngredient(null,"perfectpurity", 1);
			recipe.AddIngredient(ItemID.GravityGlobe, 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
