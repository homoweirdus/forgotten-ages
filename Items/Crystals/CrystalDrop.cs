using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Crystals
{
    public class CrystalDrop : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
            {
               int amountToDrop = Main.rand.Next(5,10);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OblivionCrystal"), amountToDrop); 
            }
			
			if (npc.type == NPCID.BrainofCthulhu && !Main.expertMode)
            {
               int amountToDrop = Main.rand.Next(5,10);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ConfusionCrystal"), amountToDrop); 
            }
			
			if (npc.type == NPCID.EyeofCthulhu && !Main.expertMode)
            {
               int amountToDrop = Main.rand.Next(5,10);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VisionCrystal"), amountToDrop); 
            }
			
			if (npc.type == 13 && !Main.expertMode)
            {
				if (!NPC.AnyNPCs(13) || !NPC.AnyNPCs(14) || !NPC.AnyNPCs(15))
				{
					int amountToDrop = Main.rand.Next(5,10);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DominationCrystal"), amountToDrop); 
				}
            }
			
			if (npc.type == NPCID.QueenBee && !Main.expertMode)
            {
               int amountToDrop = Main.rand.Next(5,10);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("InfestationCrystal"), amountToDrop); 
            }
			
			if (npc.type == NPCID.KingSlime && !Main.expertMode)
            {
               int amountToDrop = Main.rand.Next(5,10);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChampionCrystal"), amountToDrop); 
            }
			
			if (npc.type == 35 && !Main.expertMode)
            {
               int amountToDrop = Main.rand.Next(5,10);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ExterminationCrystal"), amountToDrop); 
            }
          
        }
    }
}