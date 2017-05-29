using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Buffs
{
	public class BloodLeech : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			Main.buffName[this.Type] = "Blood Leech";
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetModInfo<NpcInfo>(mod).BloodLeech = true;
		}
	}
}