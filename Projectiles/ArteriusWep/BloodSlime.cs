using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
    public class BloodSlime : ModProjectile
	{
		int TrailCounter = 0;
    	public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.name = "Living Blood";
			projectile.CloneDefaults(ProjectileID.BabySlime);
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.aiStyle = 26;
			aiType = 266;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Blood");
			Main.projFrames[projectile.type] = 6;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			if (player.dead)
			{
				modPlayer.BloodSlime = false;
			}
			if (modPlayer.BloodSlime)
			{
				projectile.timeLeft = 2;
			}
			
			TrailCounter++;
			if (TrailCounter >= 15)
			{
				Vector2 velVect = new Vector2(projectile.velocity.X / 2, projectile.velocity.Y / 2);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-25, 25)));
				
				int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velVect2.X, velVect2.Y, mod.ProjectileType("BloodTrail"), projectile.damage, projectile.knockBack, projectile.owner);
				ProjectileID.Sets.MinionShot[Main.projectile[p].type] = true;
				TrailCounter = 0;
			}
			
			Lighting.AddLight(projectile.Center, 0.5f, 0.2f, 0f);

			if ((projectile.velocity.X > 0 || projectile.velocity.X < 0) || (projectile.velocity.Y > 0 || projectile.velocity.Y < 0))
			{
				for (int index1 = 0; index1 < 5; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + projectile.width/2, projectile.position.Y + projectile.height/2), projectile.width/2, projectile.height/2, mod.DustType("BloodDust"), 0.0f, 0.0f, 200, default(Color), 1.2f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
					Main.dust[index2].alpha = projectile.alpha;
				}
				if (Main.rand.Next(5) == 0)
				{
					int num = 4;
					int index = Dust.NewDust(new Vector2(projectile.position.X + projectile.width/2, projectile.position.Y + projectile.height/2), projectile.width/2, projectile.height/2, mod.DustType("BloodDust"), 0.0f, 0.0f, 200, default(Color), 0.6f);
					Main.dust[index].velocity *= 0.25f;
					Main.dust[index].velocity += projectile.velocity * 0.5f;
					Main.dust[index].alpha = projectile.alpha;
				}
			}
		}
    }
}
