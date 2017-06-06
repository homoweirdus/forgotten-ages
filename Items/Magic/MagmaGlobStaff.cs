using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class MagmaGlobStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;
			item.magic = true;
			item.mana = 14;
			item.width = 25;
			item.height = 26;
			item.useTime = 28;
			item.UseSound = SoundID.Item20;

			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 50000;
			item.rare = 3;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MagmaGlob");
			item.shootSpeed = 7f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Magma Glob Staff");
      Tooltip.SetDefault("Casts a slow moving ball of magma that explodes into sparks of fire on hit");
    }

	}
}
