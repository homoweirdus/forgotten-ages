using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.Melee
{
    public class searang : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Coral Boomerang";
            item.damage = 14;            
            item.melee = true;
            item.width = 30;
            item.height = 30;
            item.toolTip = "Stacks up to 3";
            item.useTime = 18;
            item.useAnimation = 18;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 480;
            item.rare = 1;
            item.shootSpeed = 12f;
			item.maxStack = 3;
            item.shoot = mod.ProjectileType ("SeaBoom");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
		
        public override bool CanUseItem(Player player)
        {
            int boomOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == item.shoot)
                {
                    boomOut++;
                }
            }
            if (boomOut > item.stack - 1)
            {
                return false;
            }
            return true;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 5);
			recipe.AddIngredient(ItemID.SharkFin, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}