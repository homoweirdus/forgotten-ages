using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace  ForgottenMemories.Items.ItemSets.GemBows
{
    public class RubyBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Ruby Longbow";
            item.damage = 16;
            item.noMelee = true;
            item.ranged = true;
            item.width = 27;
            item.height = 11;
            item.toolTip = "Arrows penetrate enemies";
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 1687500;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;
        }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RubyArrow"), damage, knockBack, player.whoAmI);
				
			return false;
		}
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}