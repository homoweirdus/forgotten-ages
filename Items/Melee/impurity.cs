using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class impurity : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Impurity";
			item.damage = 136;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "A beautiful nightmare... the blood is beautiful...";
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("improj");
			item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NightsEdge, 1);
			recipe.AddIngredient(ItemID.TrueNightsEdge, 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
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
			if (Main.rand.Next(10) == 0)
			{
				int dust4 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
				Main.dust[dust4].scale = 1.5f;
				Main.dust[dust4].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust5 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
				Main.dust[dust5].scale = 1.5f;
				Main.dust[dust5].noGravity = true;
			}
		}
	}
}
