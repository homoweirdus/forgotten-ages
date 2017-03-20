using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class DeathweedStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Deathweed Staff";
			item.damage = 9;
			item.magic = true;
			item.mana = 6;
			item.width = 21;
			item.height = 22;
			item.toolTip = "Fires piercing deathweed projectiles";
			item.useTime = 18;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			Item.staff[item.type] = true;
			item.value = 15000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DeathweedBall");
			item.shootSpeed = 9f;
		}
	}
}