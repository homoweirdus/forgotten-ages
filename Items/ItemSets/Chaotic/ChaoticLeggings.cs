using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Chaotic
{
	public class ChaoticLeggings : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Chaotic Leggings";
			item.width = 18;
			item.height = 18;
			AddTooltip("8% increased damage");
			AddTooltip2("15% movement speed");
			item.value = 140000;
			item.rare = 4;
			item.defense = 7;
			item.lifeRegen = 1;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.magicDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.minionDamage += 0.08f;
			player.moveSpeed  += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChaoticBar", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}