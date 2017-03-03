using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Ammo {
public class BeeHive : ModItem
{
	
    public override void SetDefaults()
    {
        item.name = "Bee Hive";
        item.damage = 5;
        item.ranged = true;
        item.width = 22;
        item.height = 22;
        item.toolTip = "Ammo for bows, fires bees";
		item.shootSpeed = 3f;
		item.shoot = 469;
        item.knockBack = 1;
		item.UseSound = SoundID.Item1;
        item.value = 1100000;
        item.rare = 10;
        item.ammo = AmmoID.Arrow;
		item.maxStack = 1;
		item.consumable = false;
    }
	
	        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeeWax, 20);
			recipe.AddIngredient(ItemID.EndlessQuiver, 1);
			recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
}}