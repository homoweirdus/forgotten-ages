using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgettenMemories.Items.Throwing
{
	public class Hamboy: ModItem
	{
		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Ham Shank");
        Tooltip.SetDefault("'Shouldn't this be eaten?'");
		}		
        
		public override void SetDefaults()
		{
			item.damage = 15;
			item.thrown = true;
			item.width = 30;
			item.height = 30;
            item.useAnimation = 25;
            item.useTime = 25;
            item.maxStack = 999;
			item.consumable = true;
            item.useStyle = 1;
            item.autoReuse = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 2f;
            item.value = Item.sellPrice(0, 0, 0, 1);
			item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("HamboyProj");
            item.shootSpeed = 10f;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vertebrae, 8);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RottenChunk, 8);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}
