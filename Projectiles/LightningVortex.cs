using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class LightningVortex : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.aiStyle = -1;
			projectile.alpha = 50;
            projectile.friendly = true;
            projectile.melee = true;
			projectile.timeLeft = 60;
            projectile.penetrate = -1;
			projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex");
		}
		
		   public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			}
			
			if (Main.rand.Next(5) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 211, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			}
			projectile.rotation += 0.5f;
			projectile.velocity.X *= 0.96f;
			projectile.velocity.Y *= 0.96f;
			Vector2 move = Vector2.Zero;
			float distance = 220f;
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
			if (target && timer >= 12)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 15f, move.Y * 15f, 255, (int)(projectile.damage * 0.70), 5f, projectile.owner);
				Main.projectile[proj].melee = true;
				Main.projectile[proj].magic = false;
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].tileCollide = false;
				Main.projectile[proj].timeLeft = 120;
				timer = 0;
			}
		}
    }
}