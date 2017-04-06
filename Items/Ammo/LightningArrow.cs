using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Ammo 
{
	public class LightningArrow : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Lightning Arrow";
			item.damage = 10;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			item.toolTip = "Moves somewhat randomly, but has insane velocity";
			item.shootSpeed = 18f;
			item.shoot = mod.ProjectileType("LightningArrow");
			item.knockBack = 1.2f;
			item.UseSound = SoundID.Item1;
			item.value = 35;
			item.rare = 1;
			item.ammo = AmmoID.Arrow;
			item.maxStack = 999;
			item.consumable = true;
		}
	}
}