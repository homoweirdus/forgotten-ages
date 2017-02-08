using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles {
    public class PowerKnifeProj : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "PowerKnife";
		projectile.width = 15;
		projectile.height = 28;
		projectile.aiStyle = 2;
		projectile.penetrate = 1;
		projectile.thrown = true;
		projectile.friendly = true;
        projectile.timeLeft = 3000;
	}
	
	public override void Kill(int timeLeft)
        {
        	if (Main.rand.Next(11) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("PowerKnife"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 10);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }

    public override bool PreAI()
    {
        projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * (float)projectile.direction;
        projectile.localAI[1] += 1f;
        if (projectile.localAI[1] >= 40f) // Change this '20' value if you want the knife to fly longer before dropping
        {
            projectile.velocity.Y = projectile.velocity.Y + 0.4f;
            projectile.velocity.X = projectile.velocity.X * 0.98f;
        }
        else
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }

        if (projectile.velocity.Y > 16f)
        {
            projectile.velocity.Y = 16f;
        }

        return false;
    }
}
}	