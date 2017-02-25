using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Chaotic
{
	public class ChaoticShirt : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Chaotic Shirt";
			item.width = 18;
			item.height = 18;
			AddTooltip("6% increased damage");
			AddTooltip("6% increased crit chance");
			item.value = 140000;
			item.rare = 4;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 6;
			player.magicCrit += 6;
			player.rangedCrit += 6;
			player.thrownCrit += 6;
			player.meleeDamage += 0.06f;
			player.magicDamage += 0.06f;
			player.rangedDamage += 0.06f;
			player.thrownDamage += 0.06f;
			player.minionDamage += 0.06f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChaoticBar", 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}