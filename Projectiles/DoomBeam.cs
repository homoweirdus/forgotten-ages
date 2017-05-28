using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class DoomBeam : ModProjectile
	{
		bool alreadyHit = false;
		public override void SetDefaults()
		{
			projectile.name = "Dying Reality Bolt";
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = -1;
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
					int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 62, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num165].position.X = x2;
					Main.dust[num165].position.Y = y2;
					Dust dust3 = Main.dust[num165];
					dust3.velocity *= 0f;
					Main.dust[num165].noGravity = true;
					num = num164;
				}
			}
			
						
			Vector2 targetPos = projectile.Center;
            float targetDist = 450f;
            bool targetAcquired = false;
			for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(projectile))
                {
                    float dist = projectile.Distance(Main.npc[i].Center);
                    if (dist < targetDist)
                    {
                        targetDist = dist;
                        targetPos = Main.npc[i].Center;
                        targetAcquired = true;
                    }
                }
            }

            if (targetAcquired)
            {
                float homingSpeedFactor = 5f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;
                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
				
				if (alreadyHit == false)
				{
					projectile.timeLeft++;
				}
            }
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			alreadyHit = true;
		}
	}
}