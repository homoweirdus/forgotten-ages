using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.Necro 
{
	public class NecroflameSickleProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Necroflame Sickle";
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 3;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.extraUpdates = 3;
			projectile.tileCollide = false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(153, 360, false);
			}
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
		}
	}
}	