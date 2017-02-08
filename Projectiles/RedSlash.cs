using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles {
public class RedSlash : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "RedSlash";
		projectile.width = 36;
		projectile.height = 8;
		projectile.aiStyle = 1;
		projectile.penetrate = 3;
		projectile.magic = true;
		projectile.friendly = true;
		projectile.alpha = 20;
		projectile.timeLeft = 30;
		projectile.scale = 1.5f;
	}
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
	Player player = Main.player[projectile.owner];
	player.HealEffect(2);
	player.statLife += 2;
	}
}
}	