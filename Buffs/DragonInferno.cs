using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class DragonInferno : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Draconic Inferno");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.lifeRegen >= 0)
			{
				npc.lifeRegen = 0;
			}
			npc.lifeRegen -= 25;
			npc.lifeRegen = ((int)(npc.lifeRegen * 1.25));
			npc.defense = ((int)(npc.defense * 0.1));

			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;		
			}
		}
	}
}