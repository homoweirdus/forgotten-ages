using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BlightDragon : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Blighted Drake";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 100;
			Main.projFrames[projectile.type] = 4;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			if (projectile.velocity.X <= 0)
			{
				projectile.spriteDirection = -1;
			}
			if (projectile.velocity.X >= 0)
			{
				projectile.spriteDirection = 1;
			}
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
			Vector2 move = Vector2.Zero;
			float distance = 250f;
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
			if (target)
			{
				projectile.velocity = (projectile.velocity * 20f + move * 5f)/21f;
				projectile.timeLeft++;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 60, false);
		}
		
		public override void Kill(int timeLeft)
		{
			int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("CursedBoom"), projectile.damage/3, 5f, projectile.owner);
			Main.projectile[proj].melee = false;
			Main.projectile[proj].ranged = true;
			Main.projectile[proj].penetrate = -1;
		}
	}
}