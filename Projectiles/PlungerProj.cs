using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    class PlungerProj : ModProjectile
	{
        public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.alpha = 0;
			projectile.aiStyle = 1;
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
		}
        }
    }
}
