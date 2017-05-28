using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class DreadBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Dread Bolt";
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.alpha = 255;
			projectile.timeLeft = 60;
			projectile.tileCollide = false;
			projectile.extraUpdates = 1;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void AI()
		{
			int num;
			if (projectile.timeLeft <= 358)
			{
				for (int num164 = 0; num164 < 10; num164 = num + 1)
				{
					float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
					float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num164;
					int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 61, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num165].position.X = x2;
					Main.dust[num165].position.Y = y2;
					Dust dust3 = Main.dust[num165];
					dust3.velocity *= 0f;
					Main.dust[num165].noGravity = true;
					num = num164;
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.boss == false && Main.rand.Next(10) == 0 && target.CanBeChasedBy(projectile) && target.life >= 1)
			{
				target.life = 1;
			}
		}
	}
}