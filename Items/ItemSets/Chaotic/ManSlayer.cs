using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Chaotic
{
    public class ManSlayer : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Man-Slayer";
            item.damage = 33;
            item.noMelee = true;
            item.ranged = true;
            item.width = 18;
            item.height = 38;
            item.toolTip = "Imbues wooden arrows with ichor";
            item.useTime = 6;
            item.useAnimation = 12;
			item.reuseDelay = 14;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 138000;
			item.rare = 4;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;
        }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Convert Wooden Arrows into Ichor Arrows
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.IchorArrow;
            }
            return true;
        }
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChaoticBar", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}