using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class SpiritflameChunk : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 7;
			item.height = 8;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}
		
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("SpiritflameChunk");
		  Tooltip.SetDefault("");
		}
	}
}
