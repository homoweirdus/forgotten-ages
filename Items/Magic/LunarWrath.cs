using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Magic
{
	public class LunarWrath : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Lunar Wrath";
			item.damage = 92;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 4;
			item.useAnimation = 12;
			item.reuseDelay = 18;
			item.channel = true;
			item.useStyle = 5;
			item.knockBack = 0f;
			item.value = 1000;
			item.rare = 9;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.toolTip = "Creates a slow moving, homing laser of moonlight that gains velocity over time";
			Item.staff[item.type] = true;
			item.shoot = mod.ProjectileType("LunarOrb");
			item.shootSpeed = 6f;
			item.mana = 15;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}