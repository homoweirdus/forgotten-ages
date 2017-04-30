using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
    public class TrueArtemis : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "True Artemis";
            item.damage = 60;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;
            item.toolTip = "Fires a true night arrow that splits into cursed lightning";
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("TrueNightArrow");
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 500000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				Vector2 origVect = new Vector2(speedX, speedY);
				Vector2 newVect = origVect.RotatedBy(System.Math.PI / 10);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 10);
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / 15);
				Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / 15);
				
				Projectile.NewProjectile(position.X, position.Y, origVect.X, origVect.Y, mod.ProjectileType("TrueNightArrow"), damage, knockBack, player.whoAmI, 0, 0);
				if (Main.rand.Next(5) == 0)
				{
					Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("CursedLightning"), (int)(damage * 0.66), knockBack, player.whoAmI, 0, 0);
					Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, mod.ProjectileType("CursedLightning"), (int)(damage * 0.66), knockBack, player.whoAmI, 0, 0);
					Projectile.NewProjectile(position.X, position.Y, newVect3.X, newVect3.Y, mod.ProjectileType("CursedLightning"), (int)(damage * 0.66), knockBack, player.whoAmI, 0, 0);
					Projectile.NewProjectile(position.X, position.Y, newVect4.X, newVect4.Y, mod.ProjectileType("CursedLightning"), (int)(damage * 0.66), knockBack, player.whoAmI, 0, 0);
				}
		   return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Artemis", 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1); //placeholder ingredient
			recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
