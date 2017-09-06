using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class LightningArrow : ModProjectile
	{
		int inaccurate1 = 0;
		int inaccurate2 = 0;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 2;
			projectile.timeLeft = 360;
			projectile.arrow = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Arrow");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 59, 0f, 0f); //create dust
			Main.dust[dust].scale = 0.5f; //dust is 50% smaller
			Main.dust[dust].noGravity = true; //dust is unaffected by gravity
			if (Main.rand.Next(30) == 0) // 1/30 chance every tick
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 20);
				projectile.velocity = newVect; //rotate the projectile's velocity
			}	
			if (Main.rand.Next(30) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -20);
				projectile.velocity = newVect2;
			}			
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(4) == 0 && projectile.noDropItem == false)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("LightningArrow"));
        	} // 1/4 chance to create an arrow when the projectile is killed
			for (int i = 0; i < 5; i++) //repeat 5 times
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59); //create dust when the projectile is killed
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); //create a sound
		}
	}
}