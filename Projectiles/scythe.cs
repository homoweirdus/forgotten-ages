using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class scythe : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Scythe";
            projectile.width = 14;
			projectile.height = 14;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 2;
        }
		
		public override bool PreAI()
		{
			projectile.rotation += 0.3f;
			projectile.ai[0]++;
			if (projectile.ai[0] == 50)
			{
				projectile.velocity *= 17f;
			}
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 60, 0f, 0f);
			}
			
			if (Main.rand.Next(6) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("reddust"), 0f, 0f);
			}
	
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("DevilsWrath"), 60, false);
            }
        }
    }
}
