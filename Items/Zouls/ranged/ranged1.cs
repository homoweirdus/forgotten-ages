using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Zouls.ranged

{
	public class ranged1 : ModItem
	{
		public override void SetDefaults()
		{

			item.name = "Ranged Level 1";
			item.width = 40;
			item.height = 40;
			item.toolTip = "+ 2% Ranged Damage";
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
			player.rangedDamage += 0.02f;
		}
		public override void AddRecipes()

		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "soul", 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}