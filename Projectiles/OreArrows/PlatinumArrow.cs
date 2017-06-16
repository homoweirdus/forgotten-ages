using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.OreArrows
{
	public class PlatinumArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.penetrate = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Arrow");
		}
    }
}
