using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class NecroDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Necro Dagger";
            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
			projectile.tileCollide = true;
			projectile.scale = 0.8f;
        }
		
		   public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 54, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.5f;
			Main.dust[dust].noGravity = true;
			}
			projectile.rotation += 0.5f;
			if (projectile.velocity.X > 0)
			{
				projectile.velocity.X -= 0.08f;
			}
			if (projectile.velocity.X < 0)
			{
				projectile.velocity.X += 0.08f;
			}
			projectile.velocity.Y += 0.3f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 54);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 2);
		}
    }
}