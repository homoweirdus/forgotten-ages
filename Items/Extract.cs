using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Items
{
	public class Extract : GlobalItem
	{

		 public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
			if (Main.rand.Next(250) == 0 && extractType == 3347)
			{
				resultType = mod.ItemType("Fluctuate");
				resultStack = 1;
			}
        }
	}
}