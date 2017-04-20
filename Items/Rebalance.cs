using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using ForgottenMemories.Projectiles.Info;

namespace ForgottenMemories.Items
{
	public class Rebalance : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (Config.VanillaBalance)
			{
				if (item.type == ItemID.CrystalVileShard)
				{
					item.damage = 30;
					item.toolTip2 = "Ignores 10 defense";
				}
				
				if (item.type == 3546) //celebration
				{
					item.damage = 90;
					item.useTime = 10;
					item.useAnimation = 30;
					item.reuseDelay = 60;
				}
				
				if (item.type == ItemID.DaedalusStormbow)
				{
					item.damage = 30;
					item.useTime = 22;
					item.useAnimation = 22;
				}
				
				if (item.type == ItemID.BoneGlove)
				{
					item.toolTip2 = "33% chance not to consume bone \nScales in power with progression";
					item.autoReuse = true;
					item.useTurn = true;
					
					if (NPC.downedPlantBoss)
					{
						item.useTime = 12;
						item.useAnimation = 12;
					}
				}
				
				if (item.type == ItemID.Chik)
				{
					item.toolTip2 = "Has a 1/3 chance to create crystal shards on hit";
				}
				
				if (item.type == ItemID.Flamarang)
				{
					item.damage = 42;
					item.toolTip2 = "Fires 2 boomerangs in a spread";
					item.useTime = 10;
					item.useAnimation = 10;
					item.autoReuse = true;
					item.useTurn = true;
				}
				
				if (item.type == 1910)
				{
					item.damage = 46;
				}
				
				if (item.type == ItemID.BreakerBlade)
				{
					item.damage = 56;
					item.knockBack = 6.5f;
					item.crit += 16;
					item.autoReuse = true;
					item.useTurn = true;
				}
				
				if (item.type == ItemID.ShadowbeamStaff)
				{
					item.damage = 70;
					item.mana = 6;
				}
				
				if (item.type == ItemID.StaffofEarth)
				{
					item.damage = 150;
					item.mana = 10;
					item.useTime = 25;
					item.useAnimation = 25;
				}
				
				if (item.type == ItemID.HeatRay)
				{
					item.damage = 58;
					item.toolTip = "Shoots a piercing ray of heat \nMelts through enemy hp and defense";
				}
				
				if (item.type == ItemID.NettleBurst)
				{
					item.damage = 37;
					item.toolTip2 = "Ignores 12 defense";
				}
				
				if (item.type == 3223)
				{
					item.toolTip2 = "All projectiles have 20% chance to inflict confused \nAttacking a confused enemy with a projectile fires a homing bolt towards them";
				}
			}
		}
		
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Config.VanillaBalance)
			{
				if (item.type == ItemID.Flamethrower || item.type == 1910)
				{
					int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
					Main.projectile[p].GetModInfo<Info>(mod).Flamethrower = true;
					return false;
				}
				
				if (item.type == ItemID.Flamarang)
				{
					for (int ok = 0; ok <= 1; ok++)
					{
						float sX = speedX;
						float sY = speedY;
						sX += (float)Main.rand.Next(-60, 61) * 0.06f;
						sY += (float)Main.rand.Next(-60, 61) * 0.06f;
						Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
					}
					return false;
				}
				
				if (item.type == ItemID.BoneGlove)
				{
					if (Main.hardMode)
					{
						float sX = speedX;
						float sY = speedY;
						sX += (float)Main.rand.Next(-60, 61) * 0.06f;
						sY += (float)Main.rand.Next(-60, 61) * 0.06f;
						Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
					}
					
					if (NPC.downedMoonlord)
					{
						for (int ok = 0; ok <= 2; ok++)
						{
							float sX = speedX;
							float sY = speedY;
							sX += (float)Main.rand.Next(-60, 61) * 0.06f;
							sY += (float)Main.rand.Next(-60, 61) * 0.06f;
							Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
						}
					}
				}
			}
			return true;
		}
		
		public override void GetWeaponDamage (Item item, Player player, ref int damage)
		{
			if (Config.VanillaBalance)
			{
				if (item.type == ItemID.BoneGlove)
				{
					int DamageBoost = 0;
					//int SpeedBoost = 0;
					
					if (TGEMWorld.downedTitanRock)
					{
						DamageBoost += 1;
					}
					
					if (TGEMWorld.downedGhastlyEnt)
					{
						DamageBoost += 1;
					}
					
					if (NPC.downedQueenBee)
					{
						DamageBoost += 2;
					}
					
					if (Main.hardMode)
					{
						DamageBoost += 10;
						//SpeedBoost += 1;
					}
					
					if (NPC.downedMechBossAny)
					{
						DamageBoost += 8;
					}
					
					if (NPC.downedPlantBoss)
					{
						DamageBoost += 10;
						//SpeedBoost += 2;
					}
					
					if (NPC.downedGolemBoss)
					{
						DamageBoost += 10;
					}
					
					if (NPC.downedFishron)
					{
						DamageBoost += 8;
						//SpeedBoost += 1;
					}
					
					if (DD2Event.DownedInvasionT3)
					{
						DamageBoost += 8;
					}
					
					if (NPC.downedAncientCultist)
					{
						DamageBoost += 15;
						//SpeedBoost += 1;
					}
					
					if (NPC.downedMoonlord)
					{
						DamageBoost += 18;
						//SpeedBoost += 1;
					}
					
					damage += DamageBoost;
					//item.useTime -= SpeedBoost;
					//item.useAnimation -= SpeedBoost;
				}
			}
		}
		
		public override void UpdateAccessory (Item item, Player player, bool hideVisual)
		{
			if (Config.VanillaBalance)
			{
				if (item.type == 3223)
				{
					((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).BoCBuff = true;
				}
			}
		}
		
		public override void HoldItem(Item item, Player player)
        {
            if (Config.VanillaBalance)
            {
				if (item.type == ItemID.CrystalVileShard)
				{
					player.armorPenetration += 10;
				}
				
				if (item.type == ItemID.NettleBurst)
				{
					player.armorPenetration += 12;
				}
            }
        }
	}
	
	public class Rebalance2 : GlobalProjectile
	{
		public override void OnHitNPC (Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
			if (Config.VanillaBalance)
			{
				if (projectile.type == ProjectileID.HeatRay)
				{
					target.AddBuff(24, 360, false);
					target.AddBuff(69, 360, false);
				}
				
				if (projectile.type == 632) //last prism beam
				{
					target.immune[projectile.owner] = 15;
				}
				
				if (projectile.type == ProjectileID.Chik && Main.rand.Next(3) == 0)
				{
					int amountOfProjectiles = Main.rand.Next(3, 5);
			
					for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
						float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
						int meme = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 90, (projectile.damage/4), 5f, projectile.owner);
						Main.projectile[meme].ranged = false;
						Main.projectile[meme].melee = true;
					}
				}
			}
		}
	}
}