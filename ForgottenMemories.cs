using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
	public class ForgottenMemories : Mod 
	{
		public ForgottenMemories()

		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadBackgrounds = true,
				AutoloadSounds = true,
				AutoloadGores = true
			};
		}
		
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + (" Phaseblade"), new int[]
			{
				198,
				199,
				200,
				201,
				202,
				203
			});
			RecipeGroup.RegisterGroup("AnyPhaseblade", group);
		}
		
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HermesBoots, 1);
			recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
			recipe.AddIngredient(null,"WaterShard", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(863, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FlurryBoots, 1);
			recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
			recipe.AddIngredient(null,"WaterShard", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(863, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Leather, 14);
			recipe.AddIngredient(ItemID.Cobweb, 10);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(159, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(158, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(158, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(65, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(65, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Ectoplasm, 35);
			recipe.AddIngredient(520, 12);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(1326, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(3380, 6);
			recipe.AddIngredient(169, 80);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(857, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(3380, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(934, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(18);
            recipe.SetResult(259, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Starfury, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3458, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3065, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3456, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(1553, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(3292, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3458, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3389, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(662, 40);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3458, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3063, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.RocketLauncher, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3456, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3546, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BlizzardStaff, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3457, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3570, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HeatRay, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3457, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3541, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.QueenSpiderStaff, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3459, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3569, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(1572, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3459, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3571, 1);
            recipe.AddRecipe();
		}
	}
}
