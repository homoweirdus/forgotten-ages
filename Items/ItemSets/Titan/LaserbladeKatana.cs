using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class LaserbladeKatana : ModItem
	{
		Vector2 gayvector = new Vector2(0f, -5f);
		Vector2 homovector = new Vector2(0f, 5f);
		Vector2 bivector = new Vector2(-5f, 0f);
		Vector2 lesvector = new Vector2(5f, 0f);
		public override void SetDefaults()
		{

			item.damage = 58;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 5;
			item.useAnimation = 10;

			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 1;
			item.shootSpeed = 10;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Laserblade Katana");
      Tooltip.SetDefault("Unleashes a spiral of lasers around you");
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
			Vector2 newVect = gayvector.RotatedBy(System.Math.PI / 35);
			gayvector = newVect;
			homovector = gayvector.RotatedBy(System.Math.PI);
			bivector = gayvector.RotatedBy(System.Math.PI / 2);
			lesvector = gayvector.RotatedBy(System.Math.PI / -2);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, gayvector.X, gayvector.Y, mod.ProjectileType("BallFriendly"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, homovector.X, homovector.Y, mod.ProjectileType("BallFriendly"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, bivector.X, bivector.Y, mod.ProjectileType("BallFriendly"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, lesvector.X, lesvector.Y, mod.ProjectileType("BallFriendly"), damage, 1, Main.myPlayer, 0, 0);
			Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 75);
			return false;
		}
	}
}
