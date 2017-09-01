using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class DevilFlame : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 7;
			item.height = 8;

			item.maxStack = 999;
			item.value = 1000;
			item.rare = 2;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Devil's Flame");
      Tooltip.SetDefault("Contains unholy powers");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
    }
	
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.ObsidianSkinPotion, 1);
            recipe.AddIngredient(null, "DevilFlame", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(906, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(null, "DevilFlame", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3019, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddIngredient(ItemID.MagicMissile, 1);
            recipe.AddIngredient(null, "DevilFlame", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(218, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddIngredient(ItemID.JungleRose, 1);
            recipe.AddIngredient(null, "DevilFlame", 12);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(112, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 18);
			recipe.AddIngredient(ItemID.BlueMoon, 1);
            recipe.AddIngredient(null, "DevilFlame", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(220, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodYoyo, 1);
			recipe.AddIngredient(521, 3);
            recipe.AddIngredient(null, "DevilFlame", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3290, 1);
            recipe.AddRecipe();
        }
	}
}
