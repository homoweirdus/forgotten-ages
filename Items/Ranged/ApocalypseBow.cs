using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class ApocalypseBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Apocalypse Bow";
			item.damage = 35;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 500000;
			item.rare = 7;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = mod.ProjectileType("LeechingArrow");
			item.shootSpeed = 15f;
			item.toolTip = "Fires many different types of arrows";
			item.noMelee = true;
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				int thing = type;
				switch (Main.rand.Next(4))
				{
				case 0: type = mod.ProjectileType("LeechingArrow");
					break;
				case 1: type = mod.ProjectileType("devarrow");
					break;
				case 2: type = 2;
					break;
				case 3: type = 495;
					break;
				default: break;
				}
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.05f;
				sY += (float)Main.rand.Next(-60, 61) * 0.05f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].noDropItem = true;
				type = thing;
			}
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LeechingBow", 1);
			recipe.AddIngredient(null, "DevilBow", 1);
			recipe.AddIngredient(3052, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}