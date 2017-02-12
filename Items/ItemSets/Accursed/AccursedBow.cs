using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Accursed
{
    public class AccursedBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Witch Hunter";
            item.damage = 30;
            item.noMelee = true;
            item.ranged = true;
            item.width = 27;
            item.height = 11;
            item.toolTip = "Arrows shot inflict cursed flame";
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 138000;
			item.rare = 4;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;
        }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 2; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-30, 30) * 0.05f;
				sY += (float)Main.rand.Next(-30, 30) * 0.05f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, 103, damage, knockBack, player.whoAmI);
				Main.projectile[p].noDropItem = true;
			}
			return false;
		}
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccursedBar", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}