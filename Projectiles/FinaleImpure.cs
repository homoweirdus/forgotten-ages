using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class FinaleImpure : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Finale Lightning";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 100;
			projectile.extraUpdates = 100;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			int dust2;
			dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].scale = 1.5f;
			Main.dust[dust2].noGravity = true;
			int dust3;
			dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust3].scale = 1.5f;	
			Main.dust[dust3].noGravity = true;
			int dust4;
			dust4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust4].scale = 1.5f;	
			Main.dust[dust4].noGravity = true;
			int dust5;
			dust5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust5].scale = 1.5f;	
			Main.dust[dust5].noGravity = true;
			}
			
			
			if (Main.rand.Next(10) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 10);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(10) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -10);
				projectile.velocity = newVect2;
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