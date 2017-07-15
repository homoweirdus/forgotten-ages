using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Spiritflame
 {
	public class GhastlyShotbow : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 32;
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = false;
			item.width = 22;
			item.height = 22;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.shootSpeed = 13f;
			item.shoot = mod.ProjectileType("SpiritfireArrow");
			item.useAmmo = 40;
			item.knockBack = 1;
			item.UseSound = SoundID.Item5;
			item.value = 80000;
			item.rare = 4;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ghastly Shotbow");
		  Tooltip.SetDefault("Fires a spread of 2-4 arrows that erupt into embers of ghastly fire");
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritflameChunk", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int amount = Main.rand.Next(3) + 2;
			for (int k = 0; k < amount; k++)
			{
				int spread = Main.rand.Next(-20, 21);
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(spread));
				
				Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, mod.ProjectileType("SpiritfireArrow"), damage, knockBack, Main.myPlayer, 0, 0);
			}
            return false;
        }
	}
}
