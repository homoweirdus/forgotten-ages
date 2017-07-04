using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence 
{
	public class TripleBlowpipe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.ranged = true;
			item.width = 40;
			item.height = 20;

			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 5000;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 51; 
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Dart;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Triple Blowpipe");
      Tooltip.SetDefault("Uses seeds or darts as ammo");
    }



		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 3;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.03f;
				sY += (float)Main.rand.Next(-60, 61) * 0.03f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 8);
			recipe.AddIngredient(ItemID.Topaz, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
	}
}
