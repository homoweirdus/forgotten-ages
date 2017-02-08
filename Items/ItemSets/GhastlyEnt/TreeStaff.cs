using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class TreeStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Tree Staff";
			item.damage = 9;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.toolTip = "Summons a ghastly tree to fight for you";
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 0;
			item.rare = 2;
			item.UseSound = SoundID.Item82;
			item.shoot = mod.ProjectileType("TreeMinion");
			item.shootSpeed = 20f;
			item.buffType = mod.BuffType("TreeMinion");
			item.buffTime = 3600;
		}
		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}