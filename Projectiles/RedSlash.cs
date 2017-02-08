using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class RedSlash : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Red Slash";
			projectile.width = 36;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.penetrate = 3;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.alpha = 20;
			projectile.timeLeft = 30;
			projectile.scale = 1.5f;
		}
		
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;				
		}
		
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			player.HealEffect(1);
			player.statLife += 1;
		}
	}
}	