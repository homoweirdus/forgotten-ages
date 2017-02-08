using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Gelatine
{
	public class GelatinePelter : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gelatine Pelter";
			item.damage = 11;
			item.ranged = true;
			item.width = 23;
			item.height = 13;
			item.toolTip = "Occasionally fires a chunk of gel instead of a bullet";
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 5.25f;
			item.useAmmo = AmmoID.Bullet;
        }
		
			public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	{
    		if (Main.rand.Next(4) == 0)
			{
    			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 409, damage, knockBack, player.whoAmI);
			}
    	return true; //409 is a placeholder until gel chunk projectile is added
	}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GelatineBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}