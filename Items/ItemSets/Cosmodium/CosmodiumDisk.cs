using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
    public class CosmodiumDisk : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 120;            
            item.melee = true;
            item.width = 30;
            item.height = 30;

            item.useTime = 10;
            item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.shootSpeed = 16f;
            item.shoot = mod.ProjectileType ("CosmodiumDisk");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ultra tech Disk");
      Tooltip.SetDefault("Up to 20 disks can be thrown at once, explodes on collision");
    }

		
        public override bool CanUseItem(Player player)
        {
            int disksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == item.shoot)
                {
                    disksOut++;
                }
            }
            if (disksOut > 19)
            {
                return false;
            }
            return true;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumBar", 9);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
