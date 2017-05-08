using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using ForgottenMemories.Projectiles.Info;

namespace ForgottenMemories.Items.Ranged
{
	public class Doomsday : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Doomsday Bow";
			item.damage = 105;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 500000;
			item.rare = 11;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = mod.ProjectileType("LeechingArrow");
			item.shootSpeed = 18f;
			item.toolTip = "Summons a storm of arrows";
			item.noMelee = true;
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 5; i++)
			{
				int thing = type;
				switch (Main.rand.Next(21))
				{
				case 0: type = mod.ProjectileType("LeechingArrow");
					break;
				case 1: type = mod.ProjectileType("devarrow"); //Devil Arrow
					break;
				case 2: type = 2; //Flaming Arrow
					break;
				case 3: type = 495; //Shadowflame Arrow
					break;
				case 4: type = 485; //Hellwing Bat
					break;
				case 5: type = 706; //Phantom Pheonix
					break;
				case 6: type = mod.ProjectileType("TrueNightArrow");
					break;
				case 7: type = 117; //Bone Arrow
					break;
				case 8: type = 710; //Aerial Bane
					break;
				case 9: type = 357; //Pulse Bow
					break;
				case 10: type = 639; //Luminite Arrows
					break;
				case 11: type = 278; //Ichor Arrow
					break;
				case 12: type = 103; //Cursed Arrow
					break;
				case 13: type = 1; //Wooden Arrow, Turns into terra or holy
					break;
				case 14: type = 4; //Unholy Arrow
					break;
				case 15: type = 4; //Jester Arrow
					break;
				case 16: type = 41; //Hellfire Arrow
					break;
				case 17: type = 91; //Holy Arrow
					break;
				case 18: type = 172; //Frostburn Arrow
					break;
				case 19: type = 225; //Chlorophyte Arrow
					break;
				case 20: type = 282; //Venom Arrow
					break;
				default: break;
				}
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.05f;
				sY += (float)Main.rand.Next(-60, 61) * 0.05f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].noDropItem = true;
				if (type == 1)
				{
					if (Main.rand.Next(2) == 0)
					{
						Main.projectile[p].GetModInfo<Info>(mod).Terra = true;
					}
					
					else
					{
						Main.projectile[p].GetModInfo<Info>(mod).TrueHR = true;
					}
				}
				Main.projectile[p].timeLeft = 60;
				type = thing;
			}
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocalypseBow", 1);
			recipe.AddIngredient(3019, 1); //Hellwing bow
			recipe.AddIngredient(3854, 1); //Phantom Phoenix
			recipe.AddIngredient(null,"TerraBow", 1);
			recipe.AddIngredient(682, 1); //Marrow
			recipe.AddIngredient(3859, 1); //Aerial Bane
			recipe.AddIngredient(2223, 1); //Pulse Bow
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }
	}
}