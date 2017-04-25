using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class VengeanceBulletP : ModProjectile
    {
		int j = 0;
		int k = 0;
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.magic = true;
            projectile.name = "vengeance bullets";
            projectile.width = 2;
            projectile.height = 2;
			projectile.alpha = 255;
            projectile.friendly = true;
			projectile.tileCollide = true;
            projectile.penetrate = 2;
			projectile.extraUpdates = 1;
            projectile.timeLeft = 300;
			projectile.light = 0.2f;
        }
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 269);
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			for (int i = 0; i < 200; i++)
            {
				if (Main.npc[i] == target)
				{
					j = i;
				}
			}
			projectile.damage = (int)projectile.damage/5;
			projectile.tileCollide = false;	
			if (k == 0 && player.inventory[player.selectedItem].useTime >= 1)
			{
				target.immune[projectile.owner] = player.inventory[player.selectedItem].useTime;
			}
			k++;
		}

        public override void AI()
        {
			for (int i = 0; i < 8; i++)
            {
				if (Main.rand.Next(2) == 0)
				{
					int dust;
					dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 269, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 0.4f;
				}
			}
			Vector2 targetPos = projectile.Center;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (projectile.penetrate == 1 && Main.npc[j].life >= 0)
            {
				targetPos = Main.npc[j].Center;
                float homingSpeedFactor = 7f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist2 = projectile.Distance(targetPos);
                dist2 = homingSpeedFactor / dist2;
                homingVect *= dist2;

                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
        }
    }       
}
