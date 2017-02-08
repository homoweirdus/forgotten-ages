using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt {
public class ForestBlast : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Forest Blast";
        item.damage = 20;
        item.magic = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 28;
        item.useAnimation = 28;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 27000;
        item.rare = 2;
        item.UseSound = SoundID.Item20;
        item.autoReuse = true;
		item.shoot = mod.ProjectileType("ForestBlast1");
		item.shootSpeed = 10f;
		item.mana = 10;
		item.toolTip = "Fires a powered forest energy that explodes into leaves";
		item.noMelee = true;
    }
	
			public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}