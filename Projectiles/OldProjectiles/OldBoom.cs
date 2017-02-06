using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Projectiles.OldProjectiles
{
    public class OldBoom : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "OldBoom";
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;
            projectile.light = 0.5f;    
           
        } 
    }
}