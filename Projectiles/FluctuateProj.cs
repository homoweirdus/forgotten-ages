﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	class FluctuateProj : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 15f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300;
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
			target.AddBuff(BuffID.Slow,	120);
		}
		
		public override void AI()
		{
			Vector2 move = Vector2.Zero;
			float distance = 190f;
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
			if (target && timer >= 45)
			{
				int[] shoot = {121, 122, 123, 124, 125, 126, 597};
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 8f, move.Y * 8f, shoot[Main.rand.Next(0, shoot.Length)], projectile.damage, 5f, projectile.owner);
				Main.projectile[proj].melee = true;
				Main.projectile[proj].magic = false;
				timer = 0;
			}
		}
	}
}
