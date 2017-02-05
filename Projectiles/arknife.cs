using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class arknife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Arkhalis);
			projectile.name = "arknife";
			aiType = ProjectileID.Arkhalis;
			Main.projFrames[projectile.type] = 28;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Arkhalis;
			return true;

		}
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
		}
	}
}