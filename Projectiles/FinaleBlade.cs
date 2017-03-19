using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class FinaleBlade : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Finale Blade";
            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
			projectile.scale = 1.3f;
        }
		
		   public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.7f;
			Main.dust[dust].noGravity = true;
			int dust2;
			dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].scale = 0.7f;
			Main.dust[dust2].noGravity = true;
			int dust3;
			dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust3].scale = 0.7f;	
			Main.dust[dust3].noGravity = true;
			int dust4;
			dust4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust4].scale = 0.7f;	
			Main.dust[dust4].noGravity = true;
			int dust5;
			dust5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust5].scale = 0.7f;	
			Main.dust[dust5].noGravity = true;
			}
			projectile.rotation += 3;
			if (Main.rand.Next(5) == 0)
			{
			float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
			float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX + projectile.velocity.X, sY + projectile.velocity.Y, mod.ProjectileType("climaxproj"), projectile.damage, 5f, projectile.owner);	
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(24, 1800, false);
			target.AddBuff(153, 1800, false);
			target.AddBuff(204, 1800, false);
			target.AddBuff(44, 1800, false);
			target.AddBuff(39, 1800, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 1800, false);
			target.AddBuff(mod.BuffType("Gelled"), 1800, false);
		}
    }
}