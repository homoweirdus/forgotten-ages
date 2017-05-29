using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class BloodLeech : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blood Leech";
			item.damage = 42;
			item.thrown = true;
			item.width = 44;
			item.height = 20;
			item.toolTip = "Sticks to enemies, dealing damage over time \n Creates an explosion of blood when killing an enemy";
			item.useStyle = 1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 2;
			item.useTime = 18;
			item.useAnimation = 18;
			item.value = 140000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BloodLeech");
			item.shootSpeed = 10f;
			item.consumable = true;
			item.maxStack = 999;
		}
	}
}