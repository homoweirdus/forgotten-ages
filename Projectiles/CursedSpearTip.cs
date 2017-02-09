using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class CursedSpearTip : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Cursed Lance Tip";
			projectile.width = 40;
			projectile.height = 88;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 500;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = false;
		}
		
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("CursedBoom"), 50, 5f, projectile.owner);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(39, 360, false);
			}
		}
	}
}