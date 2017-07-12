using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class VoidboltStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 180;
			item.magic = true;
			item.mana = 12;
			item.width = 25;
			item.height = 26;
			item.useTime = 7;
			item.UseSound = SoundID.Item43;
			item.channel = true;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.noUseGraphic = true;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = 650000;
			item.rare = 11;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("VoidboltStaff");
			item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Voidbolt Staff");
		  Tooltip.SetDefault("Fires a spread of chargable shadowbeams");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowbeamStaff, 1);
			recipe.AddIngredient(null, "LaserbeamStaff", 1);
			recipe.AddIngredient(null,"CosmodiumBar", 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
