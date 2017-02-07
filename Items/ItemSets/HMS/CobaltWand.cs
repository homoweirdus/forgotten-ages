using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class CobaltWand : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cobalt Wand";
            item.damage = 40;
            item.magic = true;
            item.mana = 6;
            item.width = 13;
            item.height = 14;
            item.toolTip = "Fires high-velocity bolts of energy!";
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = 69000;
            Item.staff[item.type] = true;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = (122);
            item.shootSpeed = 25f;
			item.UseSound = SoundID.Item20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
			int p4 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 0);
			Main.projectile[p4].penetrate = 2;
			return false;
		}
    }
}