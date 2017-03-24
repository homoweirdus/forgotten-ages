using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class DamnationStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Damnation Staff";
			item.damage = 33;
			item.magic = true;
			item.mana = 8;
			item.width = 25;
			item.height = 26;
			item.toolTip = "Fires an exploding orb";
			item.useTime = 13;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 200000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("hellorb");
			item.shootSpeed = 16f;
		}
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.02f;
			sY += (float)Main.rand.Next(-60, 61) * 0.02f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(null,"DevilFlame", 15);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}