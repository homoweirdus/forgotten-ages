using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmorockStaff : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{
			item.name = "Cosmic Sceptre";
			item.damage = 44;
			item.magic = true;
			AddTooltip("Fires homing bolts, every 5 uses nearby enemies explode");
			item.width = 50;
			item.height = 50;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 70000;
			item.rare = 4;
			item.mana = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CosmorockLaser");
			item.shootSpeed = 8f;
			item.noMelee = true;
			Item.staff[item.type] = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter++;
			
			if (counter > 4)
			{
				Vector2 move = Vector2.Zero;
				float distance = 2000f;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
					{
						Vector2 newMove = Main.npc[k].Center - player.Center;
						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance)
						{
							newMove.Normalize();
							move = newMove * 20;
							distance = distanceTo;
							int proj = Projectile.NewProjectile(Main.npc[k].Center.X, Main.npc[k].Center.Y, 0f, 0f, mod.ProjectileType("CosmirockMeteor"), damage, knockBack, player.whoAmI);
							Main.projectile[proj].melee = false;
							Main.projectile[proj].magic = true;
							Main.projectile[proj].timeLeft = 2;
							Main.projectile[proj].tileCollide = false;
						}
					}
				}
				counter = 0;
			}
			return true;
		}
	}
}