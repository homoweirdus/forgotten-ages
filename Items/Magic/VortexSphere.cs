using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Magic 
{
	public class VortexSphere : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Lightning Sphere";
			item.damage = 75;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 55;
			item.useAnimation = 55;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 500000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.toolTip = "Summons an orb of electricity that shoots lightning at nearby enemies";
			item.shoot = mod.ProjectileType("LightningSphere");
			item.shootSpeed = 4f;
			item.mana = 45;
		}
	}
}