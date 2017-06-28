using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class Bubblethrower : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 13;
			item.ranged = true;
			item.width = 44;
			item.height = 20;

			item.useTime = 6;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 40000;
			item.rare = 1;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("bubblestream");
			item.shootSpeed = 5.25f;
			item.useAmmo = AmmoID.Gel;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bubblethrower");
      Tooltip.SetDefault("Shoots streams of bubbles that wil shoot homing bubbles in addition \n 2% chance to consume ammo");
    }

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(50) == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}
	}
}
