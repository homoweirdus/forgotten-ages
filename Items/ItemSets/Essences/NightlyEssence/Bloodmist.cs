using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence {
public class Bloodmist : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Bloodmist";
        item.damage = 15;
        item.magic = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 7;
        item.useAnimation = 7;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 10000;
        item.rare = 2;
        item.UseSound = SoundID.Item20;
        item.autoReuse = true;
		item.shoot = mod.ProjectileType("BloodmistProj");
		item.shootSpeed = 10f;
		item.mana = 4;
		item.toolTip = "Shoots a bloodmist cloud that expands on impact with an enemy";
		item.noMelee = true;
    }
	
			public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 10);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}