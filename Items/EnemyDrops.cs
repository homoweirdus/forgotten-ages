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
			
			if (npc.type == NPCID.KingSlime && !Main.expertMode && Main.rand.Next(8) == 0)
            {
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeRod"), 1); 
            }
			
			if (npc.type == 32)
            {
               int amountToDrop = Main.rand.Next(1,2);
               Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaterCrystal"), amountToDrop); 
            }
          
        }
    }
}