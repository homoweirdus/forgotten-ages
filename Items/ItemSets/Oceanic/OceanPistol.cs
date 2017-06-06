using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class OceanPistol : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 21;
			item.ranged = true;
			item.width = 32;
			item.height = 20;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 5.25f;
			item.useAmmo = AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ocean Pistol");
      Tooltip.SetDefault("Has a chance to shoot a bubble");
    }

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 2);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(3) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, (int)(speedX/2), (int)(speedY/2), mod.ProjectileType("buble"), (int)(damage/2), knockBack, player.whoAmI);
			}
			return true;
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
	}
}
