using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class CursedBranch : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Cursed Branch";
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 50;
            projectile.extraUpdates = 1;
			projectile.alpha = 255;
        }
		
		   public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 75, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			int kys;
			kys = Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 77, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[kys].scale = 1.5f;
			Main.dust[kys].noGravity = true;
			
			
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
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(39, 180, false);
            }
        }
    }
}