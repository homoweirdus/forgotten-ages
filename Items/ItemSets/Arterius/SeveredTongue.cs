using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class SeveredTongue : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Severed Tongue";
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 42;
			item.useTime = 42;
			item.toolTip = "Leaves behind a trail of weak blood";
			item.shootSpeed = 16f;
			item.knockBack = 3.75f;
			item.damage = 45;
			item.value = 140000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("SeveredTongue");
		}
	}
}