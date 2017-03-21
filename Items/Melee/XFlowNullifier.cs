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
			item.damage = 158;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Releases piercing stars from the sky";
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
			for (int i = 0; i < 4; ++i)
			{
				Vector2 mouse = Main.MouseWorld;
				mouse.X += Main.rand.Next(-20, 21);
				mouse.Y += Main.rand.Next(-20, 21);
				float sX = speedX;
				float sY = 25;
				sX += (float)Main.rand.Next(-30, 15) * 0.2f;
				sY += (float)Main.rand.Next(-10, 30) * 0.2f;
				int proj = Projectile.NewProjectile(mouse.X, (position.Y-1000), sX, sY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
