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
		public bool breakShop;
		public bool CosmicPowers;
		public float rangedVelocity;
		
		public override void ResetEffects()
		{
			GroundPound = false;
			AquaPowers = false;
			isGlitch = false;
			CosmicPowers = false;
			rangedVelocity = 1f;
		}
		
		
		public override void SetupStartInventory(IList<Item> items)
		{
			Item item = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item.SetDefaults(mod.ItemType("OldBlade"));
				items.RemoveAt(0);
				items.Insert(0, item);
			}
			
			
			Item item2 = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item2.SetDefaults(mod.ItemType("OldPick"));
				items.RemoveAt(1);
				items.Insert(1, item2);
			}
			
			
			Item item3 = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item3.SetDefaults(mod.ItemType("OldAxe"));
				items.RemoveAt(2);
				items.Insert(2, item3);
			}
		}
		
		public override void PreUpdate() 
		{
			if (GroundPound == true && player.controlUp && player.velocity.Y > 0)
			{
				player.velocity.Y *= 0.75f;
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 70, 0f, player.whoAmI, 0f, 0f);
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 70, 0f, player.whoAmI, 0f, 0f);
				player.velocity.Y = 30f;
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Pound = true;
			}
			
			if (GroundPound && Pound && player.controlDown)
			{
				if (player.velocity.Y == 0f)
				{
					Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlameBoom"), 105, 0f, player.whoAmI, 0f, 0f);
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
			
			if (CosmicPowers == true && player.statLife <= (int)(player.statLifeMax2 / 2))
			{
				player.AddBuff(mod.BuffType("CosmicBoon"), 2, false);
			}
		}
		
		public override bool Shoot (Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			speedX *= rangedVelocity;
			speedY *= rangedVelocity;
			return true;
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
			
			if (CosmicPowers == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 3);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.1f;
					float pX = (float)Main.rand.Next(-120, 120) * 2;
					int projectile = Projectile.NewProjectile(player.Center.X + pX, player.Center.Y - 500, sX, 5, mod.ProjectileType("CosmirockMeteor"), 45, 0f, player.whoAmI, 0f, 0f);
					Main.projectile[projectile].melee = false;
					Main.projectile[projectile].timeLeft = 1000;
				}
			}
		}
	}
}