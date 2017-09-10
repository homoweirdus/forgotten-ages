using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class HamboyProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.thrown = true;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			aiType = ProjectileID.BoneGloveProj;
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
