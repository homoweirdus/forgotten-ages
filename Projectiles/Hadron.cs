using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class Hadron : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			//projectile.aiStyle = 75;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;	
			Main.projFrames[projectile.type] = 9;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hadron");
		}
		
		public override void AI()
		{
			float num1 = 0.0f;
			Player player1 = Main.player[projectile.owner];
			Vector2 vector2_1 = player1.RotatedRelativePoint(player1.MountedCenter, true);
			if (projectile.spriteDirection == -1)
				num1 = 3.141593f;
			++projectile.ai[0];
			int num2 = 0;
			if ((double) projectile.ai[0] >= 40.0)
				++num2;
			if ((double) projectile.ai[0] >= 80.0)
				++num2;
			if ((double) projectile.ai[0] >= 120.0)
				++num2;
			int num3 = 25;
			int num4 = 0;
			--projectile.ai[1];
			bool flag = false;
			int num5 = -1;
			if ((double) projectile.ai[1] <= 0.0)
			{
				projectile.ai[1] = (float) (num3 - num4 * num2);
				flag = true;
				if ((int) projectile.ai[0] / (num3 - num4 * num2) % 7 == 0)
					num5 = 0;
			}
			projectile.frameCounter += (1 + num2);
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = projectile.frame + 1;
				if (projectile.frame >= Main.projFrames[projectile.type])
					projectile.frame = 0;
			}
			if (flag && Main.myPlayer == projectile.owner)
			{
				bool canShoot = player1.channel && player1.HasAmmo(player1.inventory[player1.selectedItem], true) && !player1.noItems && !player1.CCed;
				int shoot = 14;
				float speed = 14f * ((num2 / 6) + 1);
				int weaponDamage = player1.GetWeaponDamage(player1.inventory[player1.selectedItem]) * ((num2 / 6) + 1);
				float knockBack = player1.inventory[player1.selectedItem].knockBack;
				if (canShoot)
				{
					player1.PickAmmo(player1.inventory[player1.selectedItem], ref shoot, ref speed, ref canShoot, ref weaponDamage, ref knockBack, false);
					float weaponKnockback = player1.GetWeaponKnockback(player1.inventory[player1.selectedItem], knockBack);
					float num6 = player1.inventory[player1.selectedItem].shootSpeed * projectile.scale * ((num2 / 6) + 1);
					Vector2 vector2_2 = vector2_1;
					Vector2 vector2_3 = ((Main.screenPosition + new Vector2((float) Main.mouseX, (float) Main.mouseY)) - vector2_2);
					if ((double) player1.gravDir == -1.0)
						vector2_3.Y = ((float) (Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector2_2.Y);
					Vector2 vector2_4 = Vector2.Normalize(vector2_3);
					if (float.IsNaN((float) vector2_4.X) || float.IsNaN((float) vector2_4.Y))
						vector2_4 = Vector2.UnitY;
					Vector2 vector2_5 = (vector2_4 * num6).RotatedBy(Main.rand.NextDouble() * 0.130899697542191 - 0.0654498487710953);
					if (vector2_5.X != projectile.velocity.X || vector2_5.Y != projectile.velocity.Y)
						projectile.netUpdate = true;
					projectile.velocity = vector2_5;
					for (int index = 0; index < 4; ++index)
					{
						Vector2 vector2_6 = (Vector2.Normalize(projectile.velocity) * speed).RotatedBy(Main.rand.NextDouble() * 0.196349546313286 - 0.0981747731566429);
						if (float.IsNaN((float) vector2_6.X) || float.IsNaN((float) vector2_6.Y))
							vector2_6 = (Vector2.UnitY);
						Projectile.NewProjectile((float) vector2_2.X, (float) vector2_2.Y, (float) vector2_6.X, (float) vector2_6.Y, shoot, weaponDamage, weaponKnockback, projectile.owner, 0.0f, 0.0f);
					}
					float num7 = 8f;
					for (int index = 0; index < 1; ++index)
					{
						Vector2 vector2_6 = (Vector2.Normalize(projectile.velocity) * num7).RotatedBy(Main.rand.NextDouble() * 0.392699092626572 - 0.196349546313286);
						if (float.IsNaN((float) vector2_6.X) || float.IsNaN((float) vector2_6.Y))
							vector2_6 = (Vector2.UnitY);
						Projectile.NewProjectile((float) vector2_2.X, (float) vector2_2.Y, (float) vector2_6.X, (float) vector2_6.Y, 616, weaponDamage * 2, weaponKnockback * 1.25f, projectile.owner, 0.0f, 0.0f);
						
						Main.PlaySound(SoundID.Item36, projectile.position);
					}
				}
				else
					projectile.Kill();
			}
			
			projectile.position.Y += player1.gravDir * 2;
		}
	}
}