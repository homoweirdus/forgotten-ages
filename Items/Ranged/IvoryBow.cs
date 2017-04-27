using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class IvoryBow : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{
			item.name = "Ivory Longbow";
			item.damage = 45;
			item.ranged = true;
			item.width = 27;
			item.height = 54;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 500000;
			item.rare = 4;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			AddTooltip("Fires a piercing ivory laser");
			item.shoot = 3;
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("IvoryLaser"), (int)(damage*0.75), knockBack, player.whoAmI);
			
			for (int i = 0; i < 2; i++)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.02f;
				sY += (float)Main.rand.Next(-60, 61) * 0.02f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightShard, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(null, "DiamondBow", 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}