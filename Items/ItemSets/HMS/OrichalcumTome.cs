using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class OrichalcumTome : ModItem
    {
		int counter = 0;
        public override void SetDefaults()
        {
            item.name = "Orichalcum Tome";
            item.damage = 39;
            item.magic = true;
            item.mana = 5;
            item.width = 14;
            item.height = 16;
            item.toolTip = "Fires petals in all directions every 4 uses";
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = 69000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = (121);
            item.shootSpeed = 17f;
			item.UseSound = SoundID.Item20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (counter >= 4)
			{
				Projectile.NewProjectile(position.X, position.Y, 0, 10, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 0, -10, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 10, 10, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 10, -10, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, -10, 10, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, -10, -10, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, 10, 0, 221, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, -10, 0, 221, damage, knockBack, player.whoAmI);
				counter = 0;
			}
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.03f;
			sY += (float)Main.rand.Next(-60, 61) * 0.03f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, 121, damage, knockBack, player.whoAmI);
			counter++;
			
			return false;
		}
    }
}