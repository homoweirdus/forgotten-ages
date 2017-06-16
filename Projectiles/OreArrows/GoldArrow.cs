using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.OreArrows
{
	public class GoldArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.penetrate = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Arrow");
		}
    }
}
