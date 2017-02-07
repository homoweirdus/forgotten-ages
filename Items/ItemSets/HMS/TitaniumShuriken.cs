using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class TitaniumShurikenP : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Shuriken);
            projectile.name = "Titanium Shuriken";
            projectile.width = 22;
            projectile.height = 22;
            projectile.penetrate = 6;
            aiType = ProjectileID.Shuriken;
            projectile.ignoreWater = true;
            projectile.timeLeft = 6000;
		}
        public override void Kill(int timeLeft)
        {
        	if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("TitaniumShuriken"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 146);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }

    }

    public class TitaniumShuriken : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.damage = 44;
            item.shoot = mod.ProjectileType("TitaniumShurikenP");
            item.name = "Titanium Shuriken";
            item.rare = 4;
			item.useTime = 13;
			item.useAnimation = 13;
            item.shootSpeed = 19f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
    }
}