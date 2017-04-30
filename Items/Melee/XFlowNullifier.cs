using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class XFlowNullifier : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "X-Flow Nullifier";
			item.damage = 138;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			AddTooltip("Fires light from the heavens");
			item.useTime = 4;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 500000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("XFlowStar");
			item.shootSpeed = 1.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3459, 30);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			mouse.X += Main.rand.Next(-20, 21);
			float sX2 = 0;
			float sY2 = 40;
			sX2 += (float)Main.rand.Next(-10, 10) * 0.2f;
			sY2 += (float)Main.rand.Next(-10, 30) * 0.2f;
			Projectile.NewProjectile(position.X, (position.Y-1000), sX2 + player.velocity.X, sY2, mod.ProjectileType("XFlowStarBlue"), damage / 2, knockBack, player.whoAmI);
			Projectile.NewProjectile(mouse.X, (position.Y-1000), sX2 + player.velocity.X, sY2, mod.ProjectileType("XFlowStarYellow"), damage / 3, knockBack, player.whoAmI);
			return false;
		}
	}
}
