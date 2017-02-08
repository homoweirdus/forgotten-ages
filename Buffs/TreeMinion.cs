using System;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class TreeMinion : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Ghastly Tree";
			Main.buffTip[Type] = "Spooky";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		
				public override void Update(Player player, ref int buffIndex)
		{
			EnergyPlayer modPlayer = (EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("TreeMinion")] > 0)
			{
				modPlayer.treeMinion = true;
			}
			if (!modPlayer.treeMinion)
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