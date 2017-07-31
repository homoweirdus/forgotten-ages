using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Snow
{
	public class PineFlyer : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 66;
			npc.height = 42;
			npc.damage = 30;
			npc.defense = 12;
			npc.lifeMax = 70;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath33;
			npc.value = 60f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			aiType = NPCID.GiantBat;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pine Flier");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
			animationType = NPCID.GiantBat;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (tile == 147) && !Main.bloodMoon && spawnInfo.player.ZoneSnow && spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.05f : 0f;
		}
		
		public override void NPCLoot()
		{
			int amountToDrop = Main.rand.Next(3,10);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BorealWood, amountToDrop);
			if(Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PineStaff"));
			}
			
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 7);      
				Main.dust[dust].scale = 1.5f;
			}
			
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 2);      
				Main.dust[dust].scale = 1.5f;
			}
		}
		
	}
}
