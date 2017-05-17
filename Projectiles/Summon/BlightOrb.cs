using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Summon
{
    public class BlightOrb : HoverShooter
	{
    	public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.name = "Blighted Orb";
			projectile.width = 46;
			projectile.height = 46;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			inertia = 20f;
			shootCool = 30f;
			shoot = mod.ProjectileType("BlightBolt");
			shootSpeed = 10f;
		}
		
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
		
		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			
			if (modPlayer.BlightOrb == true)
			{
				projectile.timeLeft = 2;
			}
		}
		
		public override bool MinionContactDamage()
        {
            return false;
        }
    }
}
