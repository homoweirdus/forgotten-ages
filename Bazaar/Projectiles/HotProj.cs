using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Bazaar.Projectiles
{
	public class HotProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 18;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.thrown = true;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Grenade;
		}
	    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire,	60);
        }
	}
}