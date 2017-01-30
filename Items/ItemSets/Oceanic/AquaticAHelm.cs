using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticAHelm : ModItem
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
			item.toolTip = "4% increased melee damage, increased life by 25";
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AquaticChestplate") && legs.type == mod.ItemType("AquaticGreaves");
		}

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.04f;
			player.statLifeMax2 += 25;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Passively create damaging bubbles, explode into water when hurt";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).AquaPowers = true;
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