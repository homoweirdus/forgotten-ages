using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
    public class MarbleKatana : ModItem
    {
        public override void SetDefaults()
        {


            item.damage = 21; 
            item.crit = 8;
            item.melee = true;
            item.knockBack = 4; 
            item.autoReuse = true; 
            item.useTurn = true; 

            item.width = 32;       
            item.height = 32;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;

            item.value = 1000;
            item.rare = 3;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Marble Katana");
      Tooltip.SetDefault("");
    }

        
    }
}
