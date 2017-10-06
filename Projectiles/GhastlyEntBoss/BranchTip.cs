using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss 
{
	public class BranchTip : ModProjectile
	{
		Vector2 position;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.alpha = (int) byte.MaxValue;
			projectile.ignoreWater = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghastly Branch");
		}
		
		public override void AI()
		{
			if ((double) projectile.ai[0] == 0.0)
			{
				projectile.alpha = projectile.alpha - 50;
				if (projectile.alpha > 0)
					return;
				projectile.alpha = 0;
				projectile.ai[0] = 1f;
				if ((double) projectile.ai[1] == 0.0)
				{
					projectile.ai[1]++;
					projectile.position = (projectile.position + (projectile.velocity * 1f));
				}
				if (projectile.type == mod.ProjectileType("BranchBody") && Main.myPlayer == projectile.owner)
				{
					int type = projectile.type;
					if ((double) projectile.ai[1] >= 12.0)
						type = mod.ProjectileType("BranchTip");
					int number = Projectile.NewProjectile((float) (projectile.position.X + projectile.velocity.X) + (float) (projectile.width / 2), (float) (projectile.position.Y + projectile.velocity.Y) + (float) (projectile.height / 2), (float) projectile.velocity.X, (float) projectile.velocity.Y, type, projectile.damage, projectile.knockBack, projectile.owner, 0.0f, 0.0f);
					Main.projectile[number].damage = projectile.damage;
					Main.projectile[number].ai[1] = projectile.ai[1] + 1f;
					NetMessage.SendData(27, -1, -1, (NetworkText) null, number, 0.0f, 0.0f, 0.0f, 0, 0, 0);
				}
			}
			else
			{
				if (projectile.alpha < 170 && projectile.alpha + 5 >= 170)
				{
					for (int index = 0; index < 3; ++index)
						Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, (float) (projectile.velocity.X * 0.025000000372529), (float) (projectile.velocity.Y * 0.025000000372529), 170, new Color(), 1.2f);
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 14, 0.0f, 0.0f, 170, new Color(), 1.1f);
				}
				projectile.alpha += 3;;
				if (projectile.alpha < (int) byte.MaxValue)
					return;
				projectile.Kill();
			}
		}
	}
}