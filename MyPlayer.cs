using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
	public class MyPlayer : ModPlayer
	{
		
		public bool GroundPound;
		public bool Pound;
		public bool AquaPowers;
		public bool isGlitch;
		
		public override void ResetEffects()
		{
			GroundPound = false;
			AquaPowers = false;
			isGlitch = false;
		}
		
		
		public override void SetupStartInventory(IList<Item> items)
		{
			items.Clear();
			Item item = new Item();
			if (Main.rand.Next(10) == 0)
			{
				item.SetDefaults(mod.ItemType("OldBlade"));
			}
			else
			{
				item.SetDefaults(3507);
			}
			items.Add(item);
			
			
			Item item2 = new Item();
			if (Main.rand.Next(10) == 0)
			{
				item2.SetDefaults(mod.ItemType("OldPick"));
			}
			else
			{
				item2.SetDefaults(3509);
			}
			items.Add(item2);
			
			
			Item item3 = new Item();
			if (Main.rand.Next(10) == 0)
			{
				item3.SetDefaults(mod.ItemType("OldAxe"));
			}
			else
			{
				item3.SetDefaults(3506);
			}
			items.Add(item3);
		}
		
		public override void PreUpdate() 
		{
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 35, 0f, player.whoAmI, 0f, 0f);
				player.velocity.Y = 23f;
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Pound = true;
			}
			
			if (GroundPound && Pound && player.controlDown)
			{
				if (player.velocity.Y == 0f)
				{
					Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlameBoom"), 35, 0f, player.whoAmI, 0f, 0f);
					Pound = false;
				}
				
			}
			
			if (AquaPowers == true && Main.rand.Next(20) == 0)
			{
				float spX = (float)Main.rand.Next(-30, 30) * 0.05f;
				float spY = (float)Main.rand.Next(-30, 30) * 0.05f;
				int projectile2 = Projectile.NewProjectile(player.position.X, player.position.Y, spX, spY, mod.ProjectileType("buble"), 6, 0f, player.whoAmI, 0f, 0f);
				Main.projectile[projectile2].melee = false;
			}
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (AquaPowers == true)
			{
				int amountOfProjectiles = Main.rand.Next(4, 6);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.1f;
					float sY = (float)Main.rand.Next(-120, 0) * 0.1f;
					int projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, 22, 45, 5f, player.whoAmI);
					Main.projectile[projectile].timeLeft = 100;
					Main.projectile[projectile].magic = false;
				}
			}
		}
		
	}
}