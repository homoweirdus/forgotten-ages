using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence {
public class ShadowBlowpipe : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Shadow Blowpipe";
        item.damage = 15;
        item.ranged = true;
        item.width = 40;
        item.height = 20;
        item.toolTip = "Uses seeds or darts as ammo";
        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 5;
        item.noMelee = true; 
        item.knockBack = 4;
        item.value = 15000;
        item.rare = 2;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
        item.shoot = 51; 
        item.shootSpeed = 16f;
        item.useAmmo = AmmoID.Dart;
    }
	
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(null, "DarkEnergy", 10);
		recipe.AddIngredient(ItemID.DemoniteBar, 10);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}