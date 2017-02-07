using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Jungle
{
    public class StingerBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Stinger Bow";
            item.damage = 17;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;
            item.toolTip = "Transforms all arrows into stinger arrows, fires like a shotgun";
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 27000;
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 5f;

        }
		
			public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = Main.rand.Next(3, 6);
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.05f;
				sY += (float)Main.rand.Next(-60, 61) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("StingerArrow"), damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger, 4);
            recipe.AddIngredient(ItemID.JungleSpores, 8);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
