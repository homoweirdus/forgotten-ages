using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Items;

namespace ForgottenMemories.Items.ItemSets.Chaotic
{
	public class ChaoticHood : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Chaotic Hood";
			item.width = 18;
			item.height = 18;
			item.toolTip = "4% increased crit chance";
			item.toolTip2 = "8% increased damage";
			item.value = 140000;
			item.rare = 4;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ChaoticShirt") && legs.type == mod.ItemType("ChaoticLeggings");
		}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.08f;
			player.meleeDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.minionDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.meleeCrit += 4;
			player.magicCrit += 4;
			player.rangedCrit += 4;
			player.thrownCrit += 4;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Taking Damage releases streams of ichor\nIncreases life regen and heart pickup range as health decreases";
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).ChaoticSet = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChaoticBar", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}