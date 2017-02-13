using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	public class SoaringSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Soaring Skyblade";
			item.damage = 15;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.toolTip = "Fires a short ranged projectile";
			item.shoot = mod.ProjectileType("meleestorm");
			item.shootSpeed = 8f;
		}
		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}