using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Accursed
{

    public class CursedBoomerang : ModItem
    {
        public override void SetDefaults()
        {

            item.name = "Cursed Boomerang";
            item.damage = 52;
            item.melee = true;
            item.knockBack = 7;
            item.autoReuse = true;
            item.width = 20;
            item.height = 36;
			item.toolTip = "Explodes into cursed fire on hit";
            item.useTime = 14;
            item.useAnimation = 14;
			item.noUseGraphic = true;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.value = 138000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("CursedBoomerang");
			item.shootSpeed = 16;

        }

        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccursedBar", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }



    }

}