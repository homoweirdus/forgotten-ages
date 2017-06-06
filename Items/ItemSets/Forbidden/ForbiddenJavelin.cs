using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenJavelin : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 80;
			item.thrown = true;
			item.width = 96;
			item.height = 88;

			item.useTime = 14;
			item.useAnimation = 14;
			item.consumable = true;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 666;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ForbiddenJavelin");
			item.shootSpeed = 12f;
			item.noMelee = true;
            item.noUseGraphic = true;
			item.maxStack = 999;
		}



    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Javelin");
      Tooltip.SetDefault("Right clicking will stab the enemy with the javelin");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 1);
			recipe.AddIngredient(3261, 6);
			recipe.AddTile(134);
			recipe.SetResult(this, 600);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 5;
				item.useTime = 16;
				item.useAnimation = 16;
				item.damage = 100;
				item.consumable = false;
				item.shoot = mod.ProjectileType("ForbiddenSpear");
				item.shootSpeed = 12f;
				if (player.ownedProjectileCounts[item.shoot] > 0)
				{
					return false;
				}
				return true;
			}
			else
			{
				item.useStyle = 1;
				item.useTime = 14;
				item.useAnimation = 14;
				item.damage = 80;
				item.shootSpeed = 16f;
				item.consumable = true;
				item.shoot = mod.ProjectileType("ForbiddenJavelin");
				if (player.ownedProjectileCounts[mod.ProjectileType("ForbiddenSpear")] > 0)
				{
					return false;
				}
				return true;
			}
			return base.CanUseItem(player);
		}
	}
}
