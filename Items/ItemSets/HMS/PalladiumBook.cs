using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class PalladiumBook : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 36;
            item.magic = true;
            item.mana = 6;
            item.width = 14;
            item.height = 16;

            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = 69000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = (597);
            item.shootSpeed = 3f;
			item.UseSound = SoundID.Item20;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Palladium Book");
      Tooltip.SetDefault("Fires a slow moving spread of inaccurate energy");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int i = 0; i < 4; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.08f;
				sY += (float)Main.rand.Next(-60, 61) * 0.08f;
				int p4 = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI, 0, 0);
				Main.projectile[p4].penetrate = 4;
			}
			return false;
		}
    }
}
