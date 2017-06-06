using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Magic
{
	public class SolarJudgement : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 152;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 12;
			item.useAnimation = 12;
			item.reuseDelay = 18;
			item.channel = true;
			item.useStyle = 5;
			item.knockBack = 0f;
			item.value = 1000;
			item.rare = 9;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			Item.staff[item.type] = true;
			item.shoot = mod.ProjectileType("SolBeam");
			item.shootSpeed = 18f;
			item.mana = 25;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Solar Judgement");
      Tooltip.SetDefault("Creates a fast moving, explosive orb of sunfire that rapisly loses velocity");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(3458, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
