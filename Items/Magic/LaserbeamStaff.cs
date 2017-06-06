using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class LaserbeamStaff : ModItem
	{
		float memer = 0f;
		public override void SetDefaults()
		{

			item.damage = 49;
			item.magic = true;
			item.mana = 8;
			item.width = 38;
			item.height = 38;
			item.useTime = 4;
			item.UseSound = SoundID.Item15;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 50000;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("laserbeam2");
			item.shootSpeed = 4f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Laserbeam Staff");
      Tooltip.SetDefault("");
    }

		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			memer += 0.1f;
			Vector2 newVect = new Vector2(speedX, speedY);
			Vector2 newVect2 = newVect.RotatedBy(Math.Sin(memer) / 2);
			Vector2 newVect3 = newVect.RotatedBy(Math.Sin(-memer) / 2);
			Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, newVect3.X, newVect3.Y, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
