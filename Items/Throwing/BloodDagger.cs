using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class BloodDagger : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 11;
			item.thrown = true;
			item.shoot = mod.ProjectileType("BloodDagger");
			item.name = "Blood Dagger";
			AddTooltip("Causes enemies to slowly lose health and explode into blood on death");
			item.consumable = true;
			item.shootSpeed = 11f;
			item.useTime = 22;
			item.useAnimation = 22;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 30;
			item.rare = 1;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}
	}
}