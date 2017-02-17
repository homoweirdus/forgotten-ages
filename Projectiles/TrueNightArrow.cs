using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class TrueNightArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "True Night Arrow"; //name
            projectile.width = 14; //Projectile's width in pixels
            projectile.height = 32; //Projectile's height in pixels
            projectile.aiStyle = 1; //The ai style. Info on AI styles is in the tmodloader documentation
            projectile.friendly = true; //Determines if it can damage you
            projectile.ranged = true; //Damage type of the projectile.
            projectile.penetrate = 1; //How many enemies it can hit.
            projectile.timeLeft = 600; //How long in ticks the projectile lasts
            projectile.light = 0.5f; //light the projectile gives off
        }
		
		public override void Kill(int timeLeft)
		{
			int amountOfProjectiles = Main.rand.Next(5, 10);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("CursedLightning"), 15, 5f, projectile.owner);
				}
		}
			
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 75, 0f, 0f);
			Main.dust[dust].scale = 1.2f;
			Main.dust[dust].noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(1) == 0)
            {
                target.AddBuff(39, 180, false);
            }
        }
    }
}