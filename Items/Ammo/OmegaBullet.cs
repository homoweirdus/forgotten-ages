using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Ammo 
{
	public class OmegaBullet : ModItem
	{	
		public override void SetDefaults()
		{
			item.name = "Omega Bullet";
			item.damage = 40;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			AddTooltip("Killing an enemy restores life and unleashes more bullets from the sky");
			AddTooltip("Homes in on enemies");
			AddTooltip("'They say this bullet pierced the heavens'");
			item.shootSpeed = 18f;
			item.shoot = mod.ProjectileType("OmegaBulletP");
			item.knockBack = 1.2f;
			item.UseSound = SoundID.Item1;
			item.value = 500000000;
			item.rare = 11;
			item.expert = true;
			item.ammo = AmmoID.Bullet;
			item.maxStack = 999;
			item.consumable = true;
		}
	}
}