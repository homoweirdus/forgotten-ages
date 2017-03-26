using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class Hadron : ModItem
	{
		int cooldown;
		public override void SetDefaults()
		{
			item.name = "Hadron";
			item.damage = 120;
			item.ranged = true;
			item.width = 200;
			item.height = 58;
			AddTooltip("Unleashes a devastatingly powerful barrage of missiles");
			AddTooltip("The missile barrage takes 10 seconds to reload");
			item.useTime = 7;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 1400000;
			item.rare = 10;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParadoxPistols", 1);
			recipe.AddIngredient(ItemID.VortexBeater, 1);
			recipe.AddIngredient(3467, 22);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-60, -20);
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(4) == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, (int)position.X, (int)position.Y, 41);
			if (((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).hadron == false)
			{
				for (int i = 0; i < 4; i++)
				{	
					float sX = speedX;
					float sY = speedY;
					sX += (float)Main.rand.Next(-60, 61) * 0.03f;
					sY += (float)Main.rand.Next(-60, 61) * 0.03f;
					Projectile.NewProjectile(position.X, (position.Y - 20), sX, sY, 616, 160, knockBack, player.whoAmI);
				}
				Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
				cooldown ++;
			}
			
			float spX = speedX;
			float spY = speedY;
			spX += (float)Main.rand.Next(-60, 61) * 0.03f;
			spY += (float)Main.rand.Next(-60, 61) * 0.03f;
			Projectile.NewProjectile(position.X, (position.Y - 20), spX, spY, type, damage, knockBack, player.whoAmI);
			if (cooldown >= 4)
			{
				cooldown = 0;
				player.AddBuff(mod.BuffType("HadronCooldown"), 600, false);
			}
			return false;
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }
	}
}