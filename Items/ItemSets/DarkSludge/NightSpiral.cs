using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.DarkSludge {
public class NightSpiral : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Night Spiral";
        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.melee = true;
        item.channel = true;
        item.noMelee = true;
        item.useAnimation = 25;
        item.useTime = 25;
        item.shootSpeed = 16f;
        item.knockBack = 3.75f;
        item.damage = 25;
        item.value = Item.sellPrice(0, 1, 30, 0);
        item.rare = 3;
        item.shoot = mod.ProjectileType("BouncyProj");
    }
	
	public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkSludge", 10);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
}}