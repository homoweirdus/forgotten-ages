using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ForbiddenJavelin : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Forbidden Javelin";
			projectile.width = 11;
			projectile.height = 11;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 1000;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			if (Main.rand.Next(2) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("ForbiddenJavelin"));
        	}
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 32, 0f, 0f);
			}
		}
	}
}