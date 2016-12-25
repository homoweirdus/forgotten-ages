using Terraria.ID;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace ForgottenMemories.Items.Souls.melee

{
	public class mel1 : ModItem
	{
		public override void SetDefaults()
		{

			item.name = "melee lvl 1";
			item.width = 40;
			item.height = 40;
			item.toolTip = "+ 2% melee damage";
			item.toolTip2 = "Compatible with Forgotten Memories";
			item.value = 0;
			item.rare = 10;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.02f;
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