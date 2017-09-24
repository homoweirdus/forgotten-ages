using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Projectiles.Summon
{
    public class DemonSigil : ModProjectile
    {
        bool shot = false;
        public override void SetDefaults()
        {
			projectile.width = 86;
			projectile.height = 86;
			projectile.aiStyle = 123;
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.sentry = true;
			//projectile.WipableTurret;
        }
		
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonic Sigil");
			Main.projFrames[projectile.type] = 4;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
		
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

        public override void AI()
        {
            projectile.velocity = Vector2.Zero;
			float num1069 = 1000f;
			{
				projectile.alpha -= 5;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
				if (projectile.direction == 0)
				{
					projectile.direction = Main.player[projectile.owner].direction;
				}
				int num3 = projectile.frameCounter + 1;
				projectile.frameCounter = num3;
				if (num3 >= 9)
				{
					projectile.frameCounter = 0;
					num3 = projectile.frame + 1;
					projectile.frame = num3;
					if (num3 >= Main.projFrames[projectile.type])
					{
						projectile.frame = 0;
					}
				}
				if (projectile.alpha == 0 && Main.rand.Next(15) == 0)
				{
					Dust dust128 = Main.dust[Dust.NewDust(projectile.Top, 0, 0, 6, 0f, 0f, 100, default(Color), 1f)];
					dust128.velocity.X = 0f;
					dust128.noGravity = true;
					dust128.fadeIn = 1f;
					dust128.position = projectile.Center + Vector2.UnitY.RotatedByRandom(6.2831854820251465) * (4f * Main.rand.NextFloat() + 26f);
					dust128.scale = 0.5f;
				}
				projectile.localAI[0] += 1f;
				if (projectile.localAI[0] >= 60f)
				{
					projectile.localAI[0] = 0f;
				}
			}
			if (projectile.ai[0] < 0f)
			{
				projectile.ai[0] += 1f;
				//if (flag69)
				//{
					projectile.ai[1] -= (float)projectile.direction * 0.3926991f / 50f;
				//}
			}
			if (projectile.ai[0] == 0f)
			{
				int num1071 = -1;
				float num1072 = num1069;
				NPC ownerMinionAttackTargetNPC6 = projectile.OwnerMinionAttackTargetNPC;
				if (ownerMinionAttackTargetNPC6 != null && ownerMinionAttackTargetNPC6.CanBeChasedBy(this, false))
				{
					float num1073 = projectile.Distance(ownerMinionAttackTargetNPC6.Center);
					if (num1073 < num1072 && Collision.CanHitLine(projectile.Center, 0, 0, ownerMinionAttackTargetNPC6.Center, 0, 0))
					{
						num1072 = num1073;
						num1071 = ownerMinionAttackTargetNPC6.whoAmI;
					}
				}
				if (num1071 < 0)
				{
					int num3;
					for (int num1074 = 0; num1074 < 200; num1074 = num3 + 1)
					{
						NPC nPC16 = Main.npc[num1074];
						if (nPC16.CanBeChasedBy(this, false))
						{
							float num1075 = projectile.Distance(nPC16.Center);
							if (num1075 < num1072 && Collision.CanHitLine(projectile.Center, 0, 0, nPC16.Center, 0, 0))
							{
								num1072 = num1075;
								num1071 = num1074;
							}
						}
						num3 = num1074;
					}
				}
				if (num1071 != -1)
				{
					projectile.ai[0] = 1f;
					projectile.ai[1] = (float)num1071;
					projectile.netUpdate = true;
					return;
				}
			}
			if (projectile.ai[0] > 0f)
			{
				int num1076 = (int)projectile.ai[1];
				if (!Main.npc[num1076].CanBeChasedBy(this, false))
				{
					projectile.ai[0] = 0f;
					projectile.ai[1] = 0f;
					projectile.netUpdate = true;
					return;
				}
				projectile.ai[0] += 1f;
				float num1077 = 45f;
				if (projectile.ai[0] >= num1077)
				{
					Vector2 vector152 = projectile.DirectionTo(Main.npc[num1076].Center);
					if (vector152.HasNaNs())
					{
						vector152 = Vector2.UnitY;
					}
					float num1078 = vector152.ToRotation();
					int num1079 = (vector152.X > 0f) ? 1 : -1;
					projectile.direction = num1079;
					projectile.ai[0] = -60f;
					projectile.ai[1] = num1078 + (float)num1079 * 3.14159274f / 16f;
					projectile.netUpdate = true;
					Player player = Main.player[projectile.owner];
					Mod mod = ModLoader.GetMod("ForgottenMemories");
					TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
					
					if (projectile.owner == Main.myPlayer)
					{
						int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector152.X * 3, vector152.Y * 3, mod.ProjectileType("FlameBolt"), projectile.damage, projectile.knockBack, projectile.owner, 0f, (float)projectile.whoAmI);
					}
				}
			}																						
        }
    }
}