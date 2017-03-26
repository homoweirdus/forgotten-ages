using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class HadronCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			Main.buffName[Type] = "Hadron Cooldown";
			Main.buffTip[Type] = "Your missile barrage is reloading";
			Main.debuff[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).hadron = true;
		}
	}
}