using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
    public class TgemPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool Servant = false;
        public static bool hasProjectile;
		public bool slimeGuard = false;
		public bool ChaoticSet = false;

        public override void ResetEffects()
        {
            Servant = false;
			slimeGuard = false;
        }
		
		public override void PreUpdate()
		{
			if (player.ownedProjectileCounts[mod.ProjectileType("SlimeGuard")] < 1 && slimeGuard == true)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("SlimeGuard"), 15, 1f, player.whoAmI, 0f, 0f);
			}	
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (ChaoticSet == true)
			{
				for (int i = 0; i < 7; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.15f;
					float sY = (float)Main.rand.Next(-120, 0) * 0.15f;
					int projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, 280, 90, 5f, player.whoAmI);
					Main.projectile[projectile].timeLeft = 120;
					Main.projectile[projectile].magic = false;
				}
			}
		}
		
		public override void UpdateBadLifeRegen()
		{
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2 * 0.75))
			{
				player.lifeRegen += 2;
				player.AddBuff (105, 1, false);
			}
			
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2/2))
			{
				player.lifeRegen += 6;
			}
			
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2 * 0.25))
			{
				player.lifeRegen += 4;
			}
				
		}
			
    }
}