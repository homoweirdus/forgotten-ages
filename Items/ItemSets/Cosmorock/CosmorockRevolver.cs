using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.Info;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmorockRevolver : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cosmorock Revolver";
			item.damage = 35;
			item.ranged = true;
			item.width = 23;
			item.height = 13;
			item.toolTip = "Bullets fired have a chance to explode";
			item.useTime = 2;
			item.useAnimation = 6;
			item.reuseDelay = 22;
			item.useStyle = 5;
			item.autoReuse = true;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 250000;
			item.rare = 4;
			item.UseSound = SoundID.Item11;
			item.shoot = 10;
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX + (Main.rand.Next(-60, 60) * 0.03f);
			float sY = speedY + (Main.rand.Next(-60, 60) * 0.03f);
			int proj = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			Main.projectile[proj].GetModInfo<Info>(mod).Cosmorock = true;
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
	}
}