using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class LeafScythe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Leaf Scythe";
			item.damage = 25;
			item.melee = true;
			item.width = 58;
			item.height = 52;
			item.toolTip = "Fires a short ranged leaf that pierces tiles and enemies";
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 27000;
			item.rare = 2;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Leaf");
			item.shootSpeed = 10f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}