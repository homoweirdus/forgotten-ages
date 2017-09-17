using Terraria.ModLoader;

namespace ForgottenMemories.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TitanMask : ModItem
	{
	    public override void SetStaticDefaults()
		{
<<<<<<< HEAD
			DisplayName.SetDefault("Titan Rock Mask");
=======
		DisplayName.SetDefault("Titan Rock Mask");
        Tooltip.SetDefault("");
>>>>>>> 4ed5cbd27a6a5a607d00c7d4019010b358c7867d
		}		
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
<<<<<<< HEAD
			item.rare = 1;
=======
			item.rare = 0;
>>>>>>> 4ed5cbd27a6a5a607d00c7d4019010b358c7867d
			item.vanity = true;
		}

		public override bool DrawHead()
		{
            return false;   
        }
            public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
		}
	}
}