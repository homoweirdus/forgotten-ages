using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class HomingSpark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Spark";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 80;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void AI()
		{
			int dust2;
			dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63, 0f, 0f);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].scale = 1.2f;
			projectile.velocity.X *= 0.96f;
			projectile.velocity.Y *= 0.96f;
			projectile.rotation += 10;
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
			Vector2 move = Vector2.Zero;
			float distance = 200f;
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
				projectile.velocity = (move * 5f);
			}
		}
	}
}	