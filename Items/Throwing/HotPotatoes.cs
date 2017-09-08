using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	class HotPotatoes : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hot Potatoes");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.thrown = true;
			item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("HotProj");
			item.width = 8;
			item.height = 28;
			item.maxStack = 1;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 40;
			item.useTime = 60;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 2;
		}
	}
}
