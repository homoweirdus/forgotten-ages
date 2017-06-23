using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class BasilWand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.magic = true;
			item.mana = 18;
			item.width = 25;
			item.height = 26;
			item.useTime = 36;
			item.UseSound = SoundID.Item43;

			item.useAnimation = 36;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 50000;
			item.rare = 3;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MagmaGlob");
			item.shootSpeed = 7f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Basil Wand");
		  Tooltip.SetDefault("Creates a spore that homes in on enemies and explodes");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			mouse.X += Main.rand.Next(-20, 21);
			mouse.Y += Main.rand.Next(-20, 21);
			int p = Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, 567 + Main.rand.Next(2), damage, knockBack, player.whoAmI);
			Main.projectile[p].magic = true;
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 18);
			recipe.AddIngredient(null,"ForestEnergy", 10);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
