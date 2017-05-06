using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class laserbeam2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Laser";
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 135;
			projectile.extraUpdates = 100;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void AI()
		{
			int num;
			for (int num164 = 0; num164 < 3; num164 = num + 1)
			{
				float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
				float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num164;
				int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 60, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num165].position.X = x2;
				Main.dust[num165].position.Y = y2;
				Dust dust3 = Main.dust[num165];
				dust3.velocity *= 0f;
				dust3.noGravity = true;
				Main.dust[num165].noGravity = true;
				num = num164;
			}
		}
	}
}