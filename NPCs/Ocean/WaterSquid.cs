using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.Ocean
{
	public class WaterSquid : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 34;
			npc.height = 52;
			npc.damage = 25;
			npc.defense = 5;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit8;
			npc.DeathSound = SoundID.NPCDeath11;
			npc.value = 60f;
			npc.knockBackResist = 5f;
			npc.aiStyle = 18;
			aiType = NPCID.BlueJellyfish;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Shard Squid");
			Main.npcFrameCount[npc.type] = 4;
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 1f;
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneBeach && NPC.downedBoss3 ? 0.06f : 0f;
		}
		public override void NPCLoot()
		{
		    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaterShard"), Main.rand.Next(1, 6));
		}
	}
}
