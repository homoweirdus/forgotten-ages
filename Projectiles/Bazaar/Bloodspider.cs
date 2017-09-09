using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class Bloodspider : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.thrown = true;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			aiType = ProjectileID.BeachBall;
		}
	}
}