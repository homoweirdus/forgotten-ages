using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class MythrilStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mythril Staff";
            item.damage = 46;
            item.magic = true;
            item.mana = 8;
            item.width = 25;
            item.height = 26;
            item.toolTip = "Fires three bolts of energy!";
            item.useTime = 31;
			item.UseSound = SoundID.Item20;
            item.useAnimation = 31;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            Item.staff[item.type] = true;
            item.value = 103500;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = (124);
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 12);
			recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
            Vector2 origVect = new Vector2(speedX, speedY);
            Vector2 newVect = origVect.RotatedBy(System.Math.PI / 20);
            Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 20);

            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 0);
            Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI, 0, 0);
            Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			return false;
        }
	}
}