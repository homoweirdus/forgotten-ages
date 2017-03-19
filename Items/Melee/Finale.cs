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
			item.damage = 222;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			AddTooltip("Releases a barrage of different projectiles");
			AddTooltip("Striking an enemy with the blade heals you and greatly reduces enemy defense");
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 2000000;
			item.rare = 10;
			item.expert = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FinaleBlade");
			item.shootSpeed = 10;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 63);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			if (Main.rand.Next(2) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FinaleImpure"), damage * 2, knockBack, player.whoAmI);
			}
			if (Main.rand.Next(2) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FinalePure"), damage * 2, knockBack, player.whoAmI);
			}
			if (Main.rand.Next(2) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FinalePlanet"), damage * 2, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(69, 1800, false);
			target.AddBuff(203, 1800, false);
			player.HealEffect((int)(damage * 0.05));
			player.statLife += ((int)(damage * 0.05));
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"Climax", 1);
			recipe.AddIngredient(null,"PlanetaryBlade", 1);
			recipe.AddIngredient(null,"CrazedImpurity", 1);
			recipe.AddIngredient(null,"perfectpurity", 1);
			recipe.AddIngredient(null,"ForcedPride", 1);
			recipe.AddIngredient(ItemID.GravityGlobe, 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
