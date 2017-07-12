using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritfireArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 42;
			projectile.aiStyle = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.scale = 0.75f;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
			//projectile.scale = 0.5f;
			//projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiritfire Dagger");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			
			
			for (int i = 0; i < Main.rand.Next(2) + 1; i++)
			{
				Vector2 vector2 = (projectile.velocity/2).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				Projectile.NewProjectile(projectile.Center, vector2, mod.ProjectileType("SpiritfireEmber"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
			Main.PlaySound(SoundID.Item34, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}