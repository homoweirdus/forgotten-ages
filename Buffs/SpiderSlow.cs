using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class SpiderSlow : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Slowed");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.boss == false && npc.type != 247 && npc.type != 248)
			{
				npc.velocity.X *= 0.5f;
				npc.velocity.Y *= 0.5f;
			}
			
			npc.lifeRegen -= 10;
		}
	}
}