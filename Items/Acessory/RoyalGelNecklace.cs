using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
 {
	public class RoyalGelNecklace : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Royal Gel Necklace";
			item.width = 24;
			item.height = 28;
			AddTooltip("Getting hit releases slime guards to protect you");
			AddTooltip("Minions have a chance to slow down enemies");
			AddTooltip("Slimes are passive");
			item.value = 140000;
			item.rare = 2;
			item.expert = true;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).jungard = true;
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).frostguard = true;
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).SlimyNeck = true;
			player.npcTypeNoAggro[1] = true;
            player.npcTypeNoAggro[16] = true;
            player.npcTypeNoAggro[59] = true;
            player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[303] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[535] = true;
			player.npcTypeNoAggro[537] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[122] = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SlimyNecklace", 1);
			recipe.AddIngredient(null, "JungleSlimePendant", 1);
			recipe.AddIngredient(null, "IceSlimeNecklace", 1);
			recipe.AddIngredient(ItemID.RoyalGel, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}