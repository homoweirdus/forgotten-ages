using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blighted Inferno Scepter";
			item.damage = 53;
			item.magic = true;
			item.toolTip = "Creates a laser that moves in a wave";
			item.width = 25;
			item.height = 25;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.knockBack = 1;
			item.value = 250000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.shoot = mod.ProjectileType("BlightedEmber2");
			item.shootSpeed = 10f;
			item.autoReuse = true;
			item.mana = 5;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (speedX <= 0)
			{
				Projectile.NewProjectile(player.Center.X + speedY, player.Center.Y + speedX, speedX, speedY, mod.ProjectileType("BlightedEmber3"), damage, knockBack, Main.myPlayer, 0, 0);
			}
			
			else
			{
				Projectile.NewProjectile(player.Center.X + speedY, player.Center.Y, speedX, speedY, mod.ProjectileType("BlightedEmber2"), damage, knockBack, Main.myPlayer, 0, 0);
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}