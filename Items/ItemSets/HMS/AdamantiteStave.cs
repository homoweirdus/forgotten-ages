using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemeories.Items.ItemSets.HMS
{
    public class AdamantiteStave : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Adamantite Laser Staff";
            item.damage = 50;
            item.magic = true;
            item.mana = 10;
            item.width = 28;
            item.height = 30;
            item.toolTip = "Fires a concentrated laser!";
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = 138000;
            Item.staff[item.type] = true;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = 126;
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
			int p4 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 0);
			Main.projectile[p4].extraUpdates = 100;
			Main.projectile[p4].penetrate = 4;
			return false;
		}
    }
}