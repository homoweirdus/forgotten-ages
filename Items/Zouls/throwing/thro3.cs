using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Zouls.throwing

{
	public class thro3 : ModItem
	{
		public override void SetDefaults()
		{

			item.name = "Throwing Level 3";
			item.width = 40;
			item.height = 40;
			item.toolTip = "+ 4% Throwing Damage";
			item.toolTip2 = "Compatible with Forgotten Memories";
			item.value = 0;
			item.rare = 10;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(5, 3);
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.04f;
		}
		public override void AddRecipes()

		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "soul", 200);
			recipe.AddIngredient(null, "ChampionCrystal", 5);
			recipe.AddIngredient(null, "thro2", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}