using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class VeilstoneBreastplate : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Blightstone Chestplate";
			item.width = 18;
			item.height = 18;
			AddTooltip("Increased life regen");
			AddTooltip("10% increased damage resistance");
			item.value = 300000;
			item.rare = 5;
			item.defense = 13;
			item.lifeRegen = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.1f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}