using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class SolarBlade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Solar Blade";
			item.damage = 148;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Fires exploding fireballs";
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 500000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SolarBall");
			item.shootSpeed = 14;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3458, 30);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.07f;
			sY += (float)Main.rand.Next(-60, 61) * 0.07f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
