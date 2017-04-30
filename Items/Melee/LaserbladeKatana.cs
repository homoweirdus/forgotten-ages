using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class LaserbladeKatana : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{
			item.name = "Laserblade Katana";
			item.damage = 43;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 10;
			item.useAnimation = 10;
			AddTooltip("Fires 3 laser waves every 4 swings");
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("laserslash");
			item.shootSpeed = 10;
		}

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter ++;
			if (counter >= 3)
			{
				Vector2 origVect = new Vector2(speedX, speedY);
				Vector2 newVect = origVect.RotatedBy(System.Math.PI / 17);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 17);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI);
				counter = 0;
			}
			return false;
		}
	}
}
