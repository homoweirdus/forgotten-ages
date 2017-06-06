using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class NecroSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 39;

			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.value = 138000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("NecroSpearP");  //put your Spear projectile name
			item.shootSpeed = 7;
			item.autoReuse = true;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bone Lance");
      Tooltip.SetDefault("Fires shadowflame skulls at nearby enemies");
    }

		
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
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
