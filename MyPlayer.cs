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
		public bool SlimeCharm;
		
		public override void ResetEffects()
		{
            GroundPound = false;
			SlimeCharm = false;
		}
		
		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(5) == 0 && SlimeCharm)
			{
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SlimeBall"), damage, knockBack, player.whoAmI);
			}
			return true;
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
        }
			
    }
}