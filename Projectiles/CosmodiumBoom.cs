using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles {
public class CosmodiumBoom : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Cosmodium Boom";
		projectile.width = 150;
		projectile.height = 150;
		projectile.aiStyle = 2;
		projectile.penetrate = -1;
		projectile.melee = true;
        projectile.timeLeft = 10;
		projectile.friendly = true;
        projectile.alpha = 255;
        projectile.tileCollide = false;
	}
    public override bool PreAI()
{
    int amountOfDust = 5;
    for (int i = 0; i < amountOfDust; ++i)
    {
        projectile.tileCollide = false;
        int dust;
        dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        Main.dust[dust].scale = 2f;
		Main.dust[dust].noGravity = true;
    }
    return false;
}
    public virtual bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }

}
}	