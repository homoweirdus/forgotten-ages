using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class MightBeam : ModProjectile
    {
		int counter = 0;
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3;
			projectile.alpha = 50;
			projectile.scale = 1.3f;
			projectile.timeLeft = 60;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Might Beam");
		}
		
		   public override void AI()
		{
			Player player = Main.player[projectile.owner];
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 29, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.2f;
			Main.dust[dust].noGravity = true;		
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
			Vector2 move = Vector2.Zero;
			Vector2 newMove = Main.MouseWorld - projectile.Center;
			if (counter == 0 && Main.mouseRight)
			{
				newMove.Normalize();
				move = newMove;
				projectile.velocity = (move * 18f);
				counter++;
			}
			if (Main.mouseRightRelease)
			{
				counter = 0;
			}
		}
		
		public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 29);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("MightBoom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
        }
    }
}