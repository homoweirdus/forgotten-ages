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
			item.damage = 13;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			AddTooltip("Fires lasers in random directions");
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
	}
}