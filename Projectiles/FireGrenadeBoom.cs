using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class FireGrenadeBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "FireGrenadeBoom";
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 2;
			projectile.penetrate = -1;
			projectile.thrown = true;
			projectile.timeLeft = 10;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		public override bool PreAI()
		{
			int amountOfProjectiles = 5;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
				float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
				projectile.tileCollide = false;
				int dust;
				dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, sX, sY);
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].noGravity = true;
			}
			return false;
		}
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180, false);
		}
	}
}	