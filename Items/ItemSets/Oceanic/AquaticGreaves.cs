using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticGreaves : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
			item.lifeRegen = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Aquatic Greaves");
      Tooltip.SetDefault("7% increased melee speed and damage");
    }


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.07f;
			player.meleeSpeed  += 0.07f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 7);
			recipe.AddIngredient(ItemID.SharkFin, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
