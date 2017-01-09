using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
    public class LaserbeamStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Laserbeam Staff";
            item.damage = 13;
            item.magic = true;
            item.mana = 7;
            item.width = 25;
            item.height = 26;
            item.useTime = 1;
			item.UseSound = SoundID.Item75;
            item.useAnimation = 4;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            Item.staff[item.type] = true;
            item.value = 50000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("laserbeam");
            item.shootSpeed = 15f;
			item.reuseDelay = 30;
        }
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
            float sX = speedX;
            float sY = speedY;
            sX += (float)Main.rand.Next(-60, 61) * 0.03f;
            sY += (float)Main.rand.Next(-60, 61) * 0.03f;
            Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
    }
	}
}