using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class ShinobiEmblem : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 14;
            item.height = 14;

            item.value = 100000;
            item.rare = 3;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Shinobi Emblem");
      Tooltip.SetDefault("Increases Thrown Damage by 15%.");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
