using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Projectiles.Spiritflame
{
    public class SpiritSlasher : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 66;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
			projectile.extraUpdates = 2;
            projectile.timeLeft = 600;  
			projectile.tileCollide = false;
        } 
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Slasher");
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
    }
}