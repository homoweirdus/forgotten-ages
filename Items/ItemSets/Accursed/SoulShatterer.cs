using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Accursed
{
	public class SoulShatterer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Soul Shatterer";
			item.damage = 20;
			item.ranged = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 50;
			item.useAnimation = 50;
			item.UseSound = SoundID.Item36;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 138000;
			item.rare = 4;
			item.autoReuse = true;
			item.toolTip = "Fires 5 cursed bullets";
			item.shoot = 10; 
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 104, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.9f, speedY * 0.9f, 104, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.8f, speedY * 0.8f, 104, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.7f, speedY * 0.7f, 104, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.6f, speedY * 0.6f, 104, damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AccursedBar", 10);
			recipe.AddIngredient(ItemID.Musket, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}