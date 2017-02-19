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
    public class TrueHallowedRepeater : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "True Hallowed Repeater";
            item.damage = 38;
            item.noMelee = true;
            item.ranged = true;
            item.width = 54;
            item.height = 24;
            item.toolTip = "Enchants arrows with hallowed energy";
            item.useTime = 8;
            item.useAnimation = 24;
			item.reuseDelay = 18;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 2;
            item.value = 500000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 12f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].GetModInfo<Info>(mod).TrueHR = true;
            return false;
        }
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedRepeater, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1); //placeholder ingredient
			recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
