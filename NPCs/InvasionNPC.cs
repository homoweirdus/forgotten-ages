using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ForgottenMemories;

namespace ForgottenMemories.NPCs
{
    public class InvasionNPC : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary< int, float > pool, NPCSpawnInfo spawnInfo)
        {
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                pool.Clear();
				
                foreach(int i in CustomInvasion.invaders)
                {
                    pool.Add(i, 1f);
                }
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                spawnRate = 250; 
                maxSpawns = 10000; 
            }
        }

        public override void PostAI(NPC npc)
        {
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                npc.timeLeft = 1000;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if(TGEMWorld.forestInvasionUp)
            {
                foreach(int invader in CustomInvasion.invaders)
                {
                    if(npc.type == invader)
                    {
                        Main.invasionSize -= 1;
                    }
                }
            }
        }
    }
}
