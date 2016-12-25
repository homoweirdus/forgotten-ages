using Terraria.ID;

using Terraria.ModLoader;


namespace ForgottenMemories.Items.Souls.defense

{
	public class def1 : ModItem

	{

		public override void SetDefaults()

		{

			item.name = "defense lvl 1";

			item.width = 40;

			item.height = 40;

			item.toolTip = "defense soul";
			item.toolTip2 = "Compatible with Forgotten Memories";

			item.value = 0;

			item.rare = 8;
			item.accessory = true;
			item.defense = 1;

			ItemID.Sets.ItemNoGravity[item.type] = true;
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