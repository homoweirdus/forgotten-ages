using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class TheFinisher : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 108;  //The width of the .png file in pixels divided by 2.
			item.damage = 98;  //Keep this reasonable please.
			item.melee = true;  //Dictates whether this is a melee-class weapon.
			item.noMelee = true;
			item.noUseGraphic = true;

			AddTooltip("Greatly reduces the defense of a low hp enemy");
			item.useAnimation = 30;
			item.useStyle = 5;
			item.useTime = 30;
			item.knockBack = 9.5f;  //Ranges from 1 to 9.
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;  //Dictates whether the weapon can be "auto-fired".
			item.height = 108;  //The height of the .png file in pixels divided by 2.
			item.maxStack = 1;
			item.value = 300000;  //Value is calculated in copper coins.
			item.rare = 8;  //Ranges from 1 to 11.
			item.shoot = mod.ProjectileType("Finisher");
			item.shootSpeed = 9;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Finisher");
      Tooltip.SetDefault("Creates energy that chains from enemy to enemy");
    }

		
		public override bool CanUseItem(Player player)
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
			recipe.AddIngredient(550, 8);
			recipe.AddIngredient(null,"MikePenceSpear", 1);
			recipe.AddIngredient(ItemID.CrystalShard, 8);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
