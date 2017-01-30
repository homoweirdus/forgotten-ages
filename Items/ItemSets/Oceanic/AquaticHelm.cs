using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticHelm : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Aquatic Helmet";
			item.width = 18;
			item.height = 18;
			item.toolTip = "4% increased magic damage";
			item.value = 10000;
			item.rare = 2;
			item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AquaticChestplate") && legs.type == mod.ItemType("AquaticGreaves");
		}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.04f;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Maximum health increased by 25";
			player.statLifeMax2 += 25;
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