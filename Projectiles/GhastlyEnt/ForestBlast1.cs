using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt {
public class ForestBlast1 : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Forest Energy";
		projectile.width = 20;
		projectile.height = 20;
		projectile.aiStyle = 0;
		projectile.penetrate = 5;
        projectile.friendly = true;
		projectile.alpha = 100;
		projectile.scale = 1.5f;
	}
	public override bool PreAI()
{
    projectile.rotation += 0.05f;
    return true;
}
}
}	