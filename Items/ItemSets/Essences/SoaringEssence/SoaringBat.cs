using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence 
{
	public class SoaringBat : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;

			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soaring Broadsword");
			Tooltip.SetDefault("Swings fast, and knocks enemies upward");
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
