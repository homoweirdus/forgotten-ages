using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet
{
	public class ColdSnap : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "ColdSnap";
			item.damage = 6;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 10;
			item.useAnimation = 10;
			item.channel = true;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 1000;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.toolTip = "Creates an expanding area of ice around you";
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ColdSnap");
			item.shootSpeed = 0f;
			item.mana = 15;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Galeshard", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}