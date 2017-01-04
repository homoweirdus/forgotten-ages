using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
    public class SlimeBall : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Slime Ball";
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 14;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 100;
        }
		
		
		public override void Kill(int timeLeft)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 4, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
        }
    }