using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class SmolSap : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 20;
			npc.damage = 60;
			npc.defense = 6;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.BlueSlime;
		}
		
		public override void NPCLoot()
		{
			Projectile.NewProjectile((int)npc.position.X, (int)npc.position.Y, 0, 0, mod.ProjectileType("Sap"), npc.damage, 0f, Main.myPlayer);
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sap Slime");
			Main.npcFrameCount[npc.type] = 2;
			animationType = NPCID.BlueSlime;
		}
	}
}
