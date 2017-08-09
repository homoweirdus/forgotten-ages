using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticKatana : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 28;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 409;
			item.shootSpeed = 7;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Aquatic Katana");
		  Tooltip.SetDefault("Fires a short ranged typhoon");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 5);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 33);
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile projectile = Main.projectile[Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, 0f)];
			projectile.magic = false;
			projectile.melee = true;
			projectile.timeLeft = 60;
			projectile.scale = 0.75f;
			projectile.GetGlobalProjectile<Info>(mod).WaterKatana = true;
			return false;
		}
	}
}
