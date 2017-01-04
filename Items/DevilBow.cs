using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
    public class DevilBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Devil's Rage";
            item.damage = 23;
            item.noMelee = true;
            item.ranged = true;
            item.width = 27;
            item.height = 11;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;
        }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
            float sY = speedY;
            sX += (float)Main.rand.Next(-60, 61) * 0.03f;
            sY += (float)Main.rand.Next(-60, 61) * 0.03f;
            Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("devarrow"), damage, knockBack, player.whoAmI);
				
			return false;
		}
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury, 1);
			recipe.AddIngredient(ItemID.HellwingBow, 1);
			recipe.AddIngredient(ItemID.LavaBucket, 5);
			recipe.AddIngredient(null, "ExterminationCrystal", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}