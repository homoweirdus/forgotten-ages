using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class GlitchSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glitch Sword";
			item.damage = 12;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Cheat weapon /n Made by kachow the god";
			item.damage = 136;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Cheat Weapon! Unobtainable outside of cheat sheet.";
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Glitch2");
			item.shootSpeed = 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Main.rand.Next(1, 713), 20, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return true; //Makes sure to not fire the original projectile
        }
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 14);
				Main.dust[dust].scale = 1.5f;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
				Main.dust[dust3].scale = 1.5f;
				Main.dust[dust3].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust4 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
				Main.dust[dust4].scale = 1.5f;
				Main.dust[dust4].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust5 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
				Main.dust[dust5].scale = 1.5f;
				Main.dust[dust5].noGravity = true;
			}
		}
		public virtual void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("glitchboom"), 50, 5f, Main.myPlayer);
		}
	}
}
