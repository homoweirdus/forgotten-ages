using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence 
{
	public class ToxicGas : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Toxic Gas";
			item.damage = 15;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 19;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 15000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ToxicGasProj");
			item.shootSpeed = 10f;
			item.mana = 4;
			item.toolTip = "Shoot toxic gas that expands on impact with a block";
			item.noMelee = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 2;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.02f;
				sY += (float)Main.rand.Next(-60, 61) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 10);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}