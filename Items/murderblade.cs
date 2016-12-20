using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items
{
	public class murderblade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Murder blade";
			item.damage = 100;
			item.melee = true;
			item.width = 62;
			item.height = 62;
			item.toolTip = "How are your hands still on?";
			item.useTime = 4;
			item.useAnimation = 4;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
	}
}
