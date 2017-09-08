using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Bazaar.Items.Weapons
{
	public class Olympus : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			Tooltip.SetDefault("-Heaven Yoyo-");
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType<Projectiles.OlympusProj>();
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 8f;

			item.knockBack = 4f;
			item.damage = 23;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 3;
		}
			
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Sediment", 1);
			recipe.AddIngredient(null, "ExoticBouquet", 1);
			recipe.AddIngredient(ItemID.Emerald, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
