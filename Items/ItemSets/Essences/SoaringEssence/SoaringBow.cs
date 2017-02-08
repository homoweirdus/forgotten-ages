using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence {
public class SoaringBow : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Soaring Bow";
        item.damage = 10;
        item.ranged = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 20;
        item.useAnimation = 20;
        item.useStyle = 5;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 2;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
		item.shoot = ProjectileID.WoodenArrowFriendly;
		item.shootSpeed = 12f;
		item.noMelee = true;
		item.useAmmo = AmmoID.Arrow;
    }
	
			public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}