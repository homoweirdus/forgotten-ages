using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class IceBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Ice Bolt";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.tileCollide = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 360;
			projectile.alpha = 255;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.2f;
			Main.dust[dust].noGravity = true;		
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
			Vector2 move = Vector2.Zero;
			Vector2 newMove = Main.MouseWorld - projectile.Center;
			if (Main.mouseLeft)
			{
				newMove.Normalize();
				move = newMove;
				projectile.velocity = (move * 18f);
			}
			if (projectile.timeLeft <= 300)
			{
				projectile.tileCollide = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 360, false);
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}