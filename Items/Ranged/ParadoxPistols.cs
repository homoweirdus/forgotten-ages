using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.Ranged
{
	public class ParadoxPistols : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 70;
			item.ranged = true;
			item.width = 23;
			item.height = 13;

			item.useTime = 4;
			item.useAnimation = 4;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 10;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Paradox Pistol");
      Tooltip.SetDefault("Fires another bullet when a bullet hits an enemy, which can create another bullet, which can create another bullet...");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-30, 30) * 0.02f;
				sY += (float)Main.rand.Next(-30, 30) * 0.02f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].GetGlobalProjectile<Info>(mod).Paradox = true;
				Main.projectile[p].tileCollide = false;
				Main.projectile[p].penetrate = 1;
			}
			return false;
		}


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3456, 18);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
    }
}
