using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class LightningSphere : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.name = "Lightning Sphere";
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = -1;
			projectile.alpha = 100;
            projectile.friendly = true;
            projectile.magic = true;
			projectile.timeLeft = 300;
            projectile.penetrate = -1;
			projectile.tileCollide = true;
        }
		
		   public override void AI()
		{
			projectile.rotation += 0.5f;
			Vector2 move = Vector2.Zero;
			float distance = 700f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			timer++;
			if (target && timer >= 8)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X + 25, projectile.Center.Y + 5, move.X * 15f, move.Y * 15f, mod.ProjectileType("ChainLightning2"), projectile.damage, 5f, projectile.owner);
				timer = 0;
			}
		}
    }
}