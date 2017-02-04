using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class perfectpurity : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Perfect Purity";
			item.damage = 100;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Fires homing bolts";
			item.useTime = 15;
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
			recipe.AddIngredient(null, "Purity", 1);
			recipe.AddIngredient(ItemID.Meowmere, 1);
			recipe.AddIngredient(3458, 30);
			recipe.AddIngredient(3459, 30);
			recipe.AddIngredient(3467, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("pinkbolt"), damage, knockBack, player.whoAmI);
			
			float sX2 = speedX;
			float sY2 = speedY;
			sX2 += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY2 += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX2, sY2, mod.ProjectileType("bluebolt"), damage, knockBack, player.whoAmI);
			
			return false;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(4) == 0)
			{
				int dust5 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 62);
				Main.dust[dust5].scale = 2f;
				Main.dust[dust5].noGravity = true;
			}
			if (Main.rand.Next(4) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 10);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
			if (Main.rand.Next(4) == 0)
			{
				int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 11);
				Main.dust[dust3].scale = 1.5f;
				Main.dust[dust3].noGravity = true;
			}
		}

	}
}
