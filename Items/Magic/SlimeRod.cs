using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class SlimeRod : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Slime Rod";
			item.damage = 12;
			item.magic = true;
			item.mana = 8;
			item.width = 25;
			item.height = 26;
			item.toolTip = "Fires slime balls";
			item.useTime = 3;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 20000;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SlimeBall");
			item.shootSpeed = 7f;
			item.reuseDelay = 30;
		}
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}