using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Throwing
 {
	public class BeamSlicer : ModItem
	{
		
		public override void SetDefaults()
		{
			item.name = "Beam Slicer";
			item.damage = 38;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			AddTooltip("Stops midair, teleports 3 times firing lasers in all directions before disappearing");
			AddTooltip("Non-consumable, but only one can be thrown at a time");
			item.width = 22;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("BeamSlicer");
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.value = 50000;
			item.rare = 2;
			item.autoReuse = true;
		}
		
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
	}
}