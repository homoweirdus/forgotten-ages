using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
    public class GraniteRifle : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Granite Decimator";
            item.damage = 32;
            item.ranged = true;
            item.width = 31;
            item.height = 32;
            item.crit = 15;
            item.toolTip = "Destroys your enemies with ease";
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Convert Musket Balls into Granite Shots
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("GraniteBullet");
            }
            return true;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
    }
}