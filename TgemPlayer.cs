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
			
    }
}