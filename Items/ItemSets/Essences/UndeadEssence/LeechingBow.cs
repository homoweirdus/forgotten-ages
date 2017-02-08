using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence {
public class LeechingBow : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Leeching Bow";
        item.damage = 20;
        item.ranged = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 17;
        item.useAnimation = 17;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 10000;
        item.rare = 2;
		item.useAmmo = 40;
        item.UseSound = SoundID.Item5;
		item.shoot = mod.ProjectileType("LeechingArrow");
		item.shootSpeed = 15f;
		item.scale = 1.1f;
		item.toolTip = "Shoots a life leeching arrow";
		item.noMelee = true;
		item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "UndeadEnergy", 10);
        recipe.AddIngredient(ItemID.Bone, 20);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}