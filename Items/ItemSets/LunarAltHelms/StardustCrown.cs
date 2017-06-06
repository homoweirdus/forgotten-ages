using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.LunarAltHelms
{
	public class StardustCrown : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			AddTooltip("Increases minion damage by 22%");
			item.value = 0;
			item.rare = 10;
			item.defense = 16;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Stardust Crown");
      Tooltip.SetDefault("Increases your max number of turrets by 1");
    }


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.StardustBreastplate && legs.type == ItemID.StardustLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).stardustCrown = true;
			player.maxTurrets += 1;
			player.setBonus = "Sentry attacks will burn enemies with stardust energy, reducing all stats \n Increased max turrets";
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxTurrets += 1;
			player.minionDamage += 0.22f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3459, 10);
			recipe.AddIngredient(3467, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
