using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class Doomsday : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Doomsday Bow";
			item.damage = 215;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 500000;
			item.rare = 7;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = mod.ProjectileType("LeechingArrow");
			item.shootSpeed = 18f;
			item.toolTip = "Fires many different types of projectiles";
			item.noMelee = true;
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 5; i++)
			{
				int thing = type;
				switch (Main.rand.Next(13))
				{
				case 0: type = mod.ProjectileType("LeechingArrow");
					break;
				case 1: type = mod.ProjectileType("devarrow");
					break;
				case 2: type = 2;
					break;
				case 3: type = 495;
					break;
				case 4: type = 485;
					break;
				case 5: type = 706;
					break;
				case 6: type = mod.ProjectileType("TrueNightArrow");
					break;
				case 7: type = 117;
					break;
				case 8: type = 710;
					break;
				case 9: type = 357;
					break;
				case 10: type = 639;
					break;
				case 11: type = 278;
					break;
				case 12: type = 103;
					break;
				default: break;
				}
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.05f;
				sY += (float)Main.rand.Next(-60, 61) * 0.05f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].noDropItem = true;
				Main.projectile[p].timeLeft = 60;
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
			recipe.AddIngredient(null, "ApocalypseBow", 1);
			recipe.AddIngredient(null, "AccursedBow", 1);
			recipe.AddIngredient(3019, 1); //Hellwing bow
			recipe.AddIngredient(3854, 1); //Phantom Phoenix
			recipe.AddIngredient(null,"TrueArtemis", 1);
			recipe.AddIngredient(682, 1); //Marrow
			recipe.AddIngredient(3859, 1); //Aerial Bane
			recipe.AddIngredient(2223, 1); //Pulse Bow
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocalypseBow", 1);
			recipe.AddIngredient(null, "ManSlayer", 1);
			recipe.AddIngredient(3019, 1); //Hellwing bow
			recipe.AddIngredient(3854, 1); //Phantom Phoenix
			recipe.AddIngredient(null,"TrueArtemis", 1);
			recipe.AddIngredient(682, 1); //Marrow
			recipe.AddIngredient(3859, 1); //Aerial Bane
			recipe.AddIngredient(3540, 1); //Phantasm
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}