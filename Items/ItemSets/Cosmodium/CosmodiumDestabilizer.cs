using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumDestabilizer : ModItem
	{
		public override void SetDefaults()
		{	
            item.name = "Cosmodium Destabilizer";
            item.toolTip = "Launches an unstable beam of chaos";
            item.damage = 143;
            item.magic = true;
            item.mana = 15;
            item.width = 40;
            item.height = 40;
            item.useTime = item.useAnimation = 60;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CosmodiumBolt");
            item.shootSpeed = 17f;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumBar", 8);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
		}
	}
}
