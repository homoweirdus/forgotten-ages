using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Optic
{
	public class OpticBlaster : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.ranged = true;
			item.width = 23;
			item.height = 13;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 27000;
            item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Optic Blaster");
      Tooltip.SetDefault("None can hide...");
    }


        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(1) == 0)
            {
                player.AddBuff(BuffID.Hunter, 2);
            }
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
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
