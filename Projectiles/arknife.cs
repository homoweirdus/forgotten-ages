using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class arknife : ModProjectile
	{
		bool dying = false;
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 11;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 250;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arknife");
		}
		

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(6) == 0 && projectile.alpha <= 150 && dying == false)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			int dust2;
			dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].noGravity = true;
			}
			projectile.alpha += 3;
			
			if (dying)
			{
				projectile.alpha += 10;
			}
			
			if (projectile.alpha >= 250)
			{
				projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!dying)
			{
				dying = true;
				projectile.tileCollide = false;
				projectile.velocity.Y /= 2;
				projectile.velocity.X /= 2;
			}
			projectile.friendly = false;
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			dying = true;
			projectile.tileCollide = false;
			projectile.velocity.Y = velocity1.Y / 2;
			projectile.velocity.X = velocity1.X / 2;
			return false;
		}
	}
}