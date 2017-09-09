﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class AtlanteanProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 10f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 250;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 8f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Chilled,	240);
		}
	}
}
