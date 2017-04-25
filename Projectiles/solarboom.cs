using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class solarboom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Solar Detonator";
			projectile.width = 25;
			projectile.height = 25;
			projectile.scale = 2f;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.timeLeft = 55;
			Main.projFrames[projectile.type] = 5;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
		}
		
		public override void AI()
		{
			if (projectile.scale == 2f)
			{
				projectile.frameCounter++;
				if (projectile.frameCounter >= 2)
				{
					projectile.frameCounter = 0;
					projectile.frame = (projectile.frame + 1);
				} 
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 180, false);
		}
	}
}	