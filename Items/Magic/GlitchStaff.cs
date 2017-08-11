using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class GlitchStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.magic = true;
			item.width = 25;
			item.height = 26;

			item.useTime = 10;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 200000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Glitch");
			item.shootSpeed = 25f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glitch Staff");
      Tooltip.SetDefault("Cheat Weapon, unobtainable without inventory editors. \n'Breaks reality'");
    }

	}
}
