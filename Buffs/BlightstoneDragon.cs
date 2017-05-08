﻿using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class BlightstoneDragon : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Blightstone Dragon";
			Main.buffTip[Type] = "A baby dragon for you";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightstoneDragon")] > 0)
			{
				modPlayer.BlightstoneDragon = true;
			}
			if (!modPlayer.BlightstoneDragon)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}