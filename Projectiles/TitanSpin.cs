using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class TitanSpin : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Chik);
			projectile.aiStyle = 99;
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = -1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan's Spin");
			aiType = 555;
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 130, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("TitanSpinP"), (int)(projectile.damage * 0.5), 5f, projectile.owner);
		}
	}
}