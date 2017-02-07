using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Optic
{
	public class OpticChainsaw : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Optic Chainsaw";
			item.damage = 36;
			item.melee = true;
			item.width = 24;
			item.height = 8;
			item.useTime = 7;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.axe = 7;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 27000;
            item.rare = 2;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("OpticChainsaw");
			item.shootSpeed = 40f;
        }

        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(1) == 0)
            {
                player.AddBuff(BuffID.Hunter, 2);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OpticBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}