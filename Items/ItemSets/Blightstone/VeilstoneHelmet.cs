using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class VeilstoneHelmet : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Veilstone Helmet";
			item.width = 18;
			item.height = 18;
			item.toolTip = "12% increased damage and 5% increased crit chance";
			item.value = 250000;
			item.rare = 5;
			item.defense = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("VeilstoneBreastplate") && legs.type == mod.ItemType("VeilstoneGreaves");
		}
		
		public override bool DrawHead()
		{
			return false;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.12f;
			player.magicDamage += 0.12f;
			player.thrownDamage += 0.12f;
			player.minionDamage += 0.12f;
			player.rangedDamage += 0.12f;
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Creates a ring of malevolent fire around you";
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).BlightFlameRing = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}