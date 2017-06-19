using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
    public class DeathweedDecimator : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 16; 
			item.crit = 20;
            item.melee = true;
            item.knockBack = 5; 
            item.autoReuse = true; 
            item.useTurn = true; 

            item.width = 32;       
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.value = 15000;
			item.rare = 1;
        } 

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Deathweed Sword");
      Tooltip.SetDefault("Critical strikes deal 50% more damage and knockback");
    }

		
		public override void ModifyHitNPC (Player player, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			if (crit == true)
			{
				damage += (int)(damage*0.5);
				knockback *= 1.5f;
			}
		}
    }
}
