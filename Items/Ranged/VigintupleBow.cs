using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class VigintupleBow : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 45;
			item.noMelee = true;
			item.ranged = true;
			item.width = 27;
			item.height = 11;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.shoot = 3;
			item.useAmmo = 40;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vigintuple Bow");
      Tooltip.SetDefault("");
    }


		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 20; i++)
			{
				int thing = type;
				switch (Main.rand.Next(10))
				{
				case 1: type = 2;
					break;
				case 2: type = 4;
					break;
				default: break;
				}
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.07f;
				sY += (float)Main.rand.Next(-60, 61) * 0.07f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].noDropItem = true;
				type = thing;
			}
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk, 12);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk, 12);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.CrimtaneBar, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
