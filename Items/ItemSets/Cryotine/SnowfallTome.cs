using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class SnowfallTome : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Snowstorm Tome";
			item.damage = 15;
			item.mana = 6;
			item.ranged = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 15;
			item.useAnimation = 15;
			item.toolTip = "Creates a storm of ice energy that follows your cursor";
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 168000;
			item.rare = 2;
			item.shoot = mod.ProjectileType("IceBolt");
			item.noMelee = true;
			item.shootSpeed = 10f;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			mouse.X += Main.rand.Next(-20, 21);
			float sX = 0;
			float sY = 25;
			sX += (float)Main.rand.Next(-10, 10) * 0.2f;
			sY += (float)Main.rand.Next(-10, 30) * 0.2f;
			Projectile.NewProjectile(mouse.X, (position.Y-1000), sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
