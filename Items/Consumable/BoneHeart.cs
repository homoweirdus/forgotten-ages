using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
	public class BoneHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Heart");
			Tooltip.SetDefault("u");
		}

		public override void SetDefaults()
		{
			item.buffType = mod.BuffType("BoneHeart");
			item.width = 20;
			item.height = 10;
			item.rare = 0;
		}
		
		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange = 100;
		}

		public override bool OnPickup(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				player.AddBuff(item.buffType, 600, true);
			}
			return false;
		}
	}
}
