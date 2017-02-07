using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class NecroflameDrill : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Necroflame Drill";
			item.damage = 26;
			item.melee = true;
			item.width = 22;
			item.height = 9;
			item.useTime = 6;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 190;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 138000;
			item.rare = 4;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecroflameDrillProj");
			item.shootSpeed = 40f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NecroBar", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}