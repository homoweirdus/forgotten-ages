using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
	[AutoloadEquip(EquipType.Head)]
	public class AssassinsHood : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 35000;
			item.rare = 1;
			item.defense = 3;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Assassin's Cowl");
      Tooltip.SetDefault("3% increased ranged critical strike chance");
    }


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AssassinsRobes") && legs.type == mod.ItemType("AssassinsTrousers");
		}

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 3;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increased ranged weapon shooting speed by 50%";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).rangedVelocity += 0.5f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GelatineBar", 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
