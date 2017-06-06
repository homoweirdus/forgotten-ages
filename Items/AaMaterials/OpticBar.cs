using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class OpticBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Optic Bar");
      Tooltip.SetDefault("");
    }

    }
}
