using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class NecroflameYoyo : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Chik);
			projectile.name = "Necroflame Yoyo";
			aiType = 555;
			projectile.aiStyle = 99;
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
			
			Vector2 move = Vector2.Zero;
			float distance = 150f;
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
			if (target && timer >= 35)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 15f, move.Y * 15f, 585, (int)(projectile.damage * 0.75), 5f, projectile.owner);
				Main.projectile[proj].melee = true;
				timer = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				target.AddBuff(153, 180, false);
			}
		}
	}
}