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

            item.damage = 45;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("TrueNightArrow");
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 500000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 15f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Erebus");
      Tooltip.SetDefault("Fires a cursed arrow that splits into flames");
    }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				Vector2 origVect = new Vector2(speedX, speedY);
				Projectile.NewProjectile(position.X, position.Y, origVect.X, origVect.Y, mod.ProjectileType("TrueNightArrow"), damage, knockBack, player.whoAmI, 0, 0);
		   return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Artemis", 1);
            recipe.AddIngredient(ItemID.CursedFlame, 20); //placeholder ingredient
			recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
