using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss {
public class GreenApple : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Green Apple";
		projectile.width = 20;
		projectile.height = 20;
		projectile.aiStyle = 14;
		projectile.penetrate = 1;
        projectile.timeLeft = 300;
		projectile.hostile = true;
        projectile.friendly = false;
		projectile.scale = 1.2f;
	}
}
}	