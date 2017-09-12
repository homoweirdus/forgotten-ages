using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class AaruProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 12f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 12f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Midas,	240);
			target.AddBuff(BuffID.OnFire,	120);
			
			int amountOfProjectiles = Main.rand.Next(3) + 1;
			
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				Vector2 newVect1 = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect1.X, newVect1.Y, 249, 10, 5f, projectile.owner);
				Main.projectile[proj].ranged = false;
				Main.projectile[proj].melee = true;
			}
		}
	}
}
