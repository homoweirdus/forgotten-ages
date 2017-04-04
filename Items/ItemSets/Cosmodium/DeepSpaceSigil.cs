using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;
namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class DeepSpaceSigil : ModItem
	{
		public override void SetDefaults()
		{	
            item.name = "Deep space sigil";
            item.toolTip = "'A lot of cosmic energy is fluxuating inside'";
            item.width = 24;
            item.height = 28;
            item.value = 50000;
            item.rare = 11;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = false;
            item.consumable = true;
            item.maxStack = 999;
        }
        public override bool UseItem(Player player)
        {
            AscensionWorld.DropComet();
            return true;
        }

    }
}
