using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class DevilsPistol : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 23;
			item.useAnimation = 23;

			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Devil Pistol");
      Tooltip.SetDefault("Has a chance to shoot an unholy fire bolt");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(3) == 0)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-20, 20) * 0.03f;
				sY += (float)Main.rand.Next(-20, 20) * 0.03f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("DevBullet"), damage, knockBack, player.whoAmI);
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 0);
		}
	}
}
