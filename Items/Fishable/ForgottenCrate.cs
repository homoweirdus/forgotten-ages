using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.Fishable
{
	public class ForgottenCrate : ModItem
    {
	  public override void SetStaticDefaults()
	  
	  {
      DisplayName.SetDefault("Forgotten Crate");
      Tooltip.SetDefault("Right Click To Open");
      }
        public override void SetDefaults()
        {
            item.maxStack = 999;  
            item.consumable = true; 
            item.width = 34;  
            item.height = 34;   
            item.rare = 4;
            item.createTile = mod.TileType("ForgottenCrateTile"); 
            item.placeStyle = 0;
            item.useAnimation = 10; 
            item.useTime = 10;  
            item.useStyle = 1;
 
 
        }
        public override bool CanRightClick() 
        {
            return true;
        }
 
        public override void RightClick(Player player)
        {
 
 
            if (NPC.downedBoss1)
            {
                int Choose = Main.rand.Next(5);         
                if (Choose == 0)                                               
                {
                    player.QuickSpawnItem(mod.ItemType("Citrine"), Main.rand.Next(1, 4));
                }
                if (Choose == 1)                                                
                {
                    player.QuickSpawnItem(mod.ItemType("Tourmaline"), Main.rand.Next(1, 4));
                }
                if (Choose == 2)                                       
                {
                    player.QuickSpawnItem(mod.ItemType("GelatineBar"), Main.rand.Next(3, 6));
                }
                if (Choose == 3)                                
                {
                    player.QuickSpawnItem(mod.ItemType("DesertEnergy"), Main.rand.Next(1, 9));
                }
                if (Choose == 4)                  
                {
                    player.QuickSpawnItem(mod.ItemType("LightningArrow"), Main.rand.Next(30, 60)); 
                }
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 5));  
            }				
            if (NPC.downedBoss2)
            {
                int Choose = Main.rand.Next(5);         
                if (Choose == 0)                                               
                {
                    player.QuickSpawnItem(mod.ItemType("Citrine"), Main.rand.Next(1, 2));
                }
                if (Choose == 1)                                                
                {
                    player.QuickSpawnItem(mod.ItemType("Tourmaline"), Main.rand.Next(1, 2));
                }
                if (Choose == 2)                                       
                {
                    player.QuickSpawnItem(mod.ItemType("DarkSludge"), Main.rand.Next(3, 9));
                }
                if (Choose == 3)                                
                {
                    player.QuickSpawnItem(mod.ItemType("CryotineBar"), Main.rand.Next(3, 10));
                }
                if (Choose == 4)                                
                {
                    player.QuickSpawnItem(mod.ItemType("SoaringEnergy"), Main.rand.Next(1, 9));
                }
                if (Choose == 5)                                
                {
                    player.QuickSpawnItem(mod.ItemType("DivineBolt"));
                }
                if (Choose == 6)                  
                {
                    player.QuickSpawnItem(mod.ItemType("LightningArrow"), Main.rand.Next(70, 240)); 
                }
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(4, 7));  
            }	
            if (NPC.downedBoss3)
            {
                int Choose = Main.rand.Next(5);         
                if (Choose == 0)                                               
                {
                    player.QuickSpawnItem(mod.ItemType("Citrine"), Main.rand.Next(3, 6));
                }
                if (Choose == 1)                                                
                {
                    player.QuickSpawnItem(mod.ItemType("Tourmaline"), Main.rand.Next(3, 6));
                }
                if (Choose == 2)                                       
                {
                    player.QuickSpawnItem(mod.ItemType("DevilFlame"), Main.rand.Next(3, 9));
                }
                if (Choose == 3)                                
                {
                    player.QuickSpawnItem(mod.ItemType("WaterShard"), Main.rand.Next(1, 8));
                }
                if (Choose == 4)                                
                {
                    player.QuickSpawnItem(mod.ItemType("UndeadEnergy"), Main.rand.Next(1, 9));
                }
                if (Choose == 5)                                
                {
                    player.QuickSpawnItem(mod.ItemType("DivineBolt"), Main.rand.Next(1, 2));
                }
                if (Choose == 6)                  
                {
                    player.QuickSpawnItem(mod.ItemType("Spinel"), Main.rand.Next(1, 6)); 
                }
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(5, 10));  
            }	
            else 
            {
                int Choose = Main.rand.Next(3);
                if (Choose == 0)                                        
                {
                    player.QuickSpawnItem(mod.ItemType("GaleShard"), Main.rand.Next(1, 17));
                }
                if (Choose == 1)                                           
                {
                    player.QuickSpawnItem(mod.ItemType("DarkEnergy"), Main.rand.Next(1, 9));
                }
                if (Choose == 2)                               
                {
                    player.QuickSpawnItem(mod.ItemType("PlungerArrow"), Main.rand.Next(30, 60)); 
                }
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 3));
 
            }
 
 
        }
 
    }
}