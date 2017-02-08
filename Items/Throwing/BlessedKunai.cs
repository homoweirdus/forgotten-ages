using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
    public class BlessedKunaiP : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.JestersArrow);
            projectile.name = "Blessed Kunai";
            projectile.width = 7;
            projectile.height = 14;
            projectile.penetrate = -1;
            aiType = ProjectileID.JestersArrow;
            projectile.ignoreWater = true;
            projectile.timeLeft = 6000;
         
         }
        
        public override void Kill(int timeLeft)
        {
        	if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BlessedKunai"));
        	}
        }

        public override void AI()
        {
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 10, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
	}}
        
        public class BlessedKunai : ModItem
        {

            public override void SetDefaults()
            {
                item.CloneDefaults(ItemID.Shuriken);
                item.damage = 49;
                item.shoot = mod.ProjectileType("BlessedKunaiP");
                item.name = "Blessed Kunai";
                item.rare = 4;
				item.useTime = 13;
				item.useAnimation = 13;
                item.shootSpeed = 9f;
				item.autoReuse = true;
            }

            public override void AddRecipes()
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.HallowedBar, 1);
                recipe.AddTile(134);
                recipe.SetResult(this, 45);
                recipe.AddRecipe();
            }
        }
    }
