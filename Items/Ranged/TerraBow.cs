using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.Info;

namespace ForgottenMemories.Items.Ranged
{
    public class TerraBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Terra Bow";
            item.damage = 46;
            item.noMelee = true;
            item.ranged = true;
            item.width = 38;
            item.height = 78;
            item.toolTip = "Fires a spread of homing terra energy";
			item.toolTip2 = "Enchants fired arrows with terra energy";
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 1000000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 12f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				Vector2 origVect = new Vector2(speedX, speedY);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 16);
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / 16);
				
				int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].GetModInfo<Info>(mod).Terra = true;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("TerraEnergy"), (int)(damage * 0.9), knockBack, player.whoAmI, 0, 0);
				Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, mod.ProjectileType("TerraEnergy"), (int)(damage * 0.9), knockBack, player.whoAmI, 0, 0);
				Projectile.NewProjectile(position.X, position.Y, newVect3.X, newVect3.Y, mod.ProjectileType("TerraEnergy"), (int)(damage * 0.9), knockBack, player.whoAmI, 0, 0);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TrueArtemis", 1);
            recipe.AddIngredient(null, "TrueHallowedRepeater", 1);
			recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}