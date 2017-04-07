using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
    public class BlueHeart : ModItem
    {
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.Heart);
            item.name = "Blue Heart";
			item.healLife = 10;
        }
    }
}
