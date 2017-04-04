using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt {
public class LeafnadoFriendly : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Leafnado";
		projectile.width = 20;
		projectile.height = 20;
		projectile.aiStyle = 0;
		projectile.penetrate = 5;
		projectile.friendly = true;
		projectile.magic = true;
        projectile.hostile = false;
		projectile.scale = 1f;
		projectile.tileCollide = true;
		Main.projFrames[projectile.type] = 6;
	}
	
	
			public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
		}
}
}	