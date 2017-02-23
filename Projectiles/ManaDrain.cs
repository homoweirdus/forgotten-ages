using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class ManaDrain : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Mana Siphon";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			target.immune[projectile.owner] = 10;
			player.statMana += 1;
			player.AddBuff (mod.BuffType("ForbiddenBoost"), 240, false);
		}
	}
}