using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
    public class TrueArtemis : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 45;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("TrueNightArrow");
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 500000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 15f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Erebus");
      Tooltip.SetDefault("Turns regular arrows into true cursed arrows");
    }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (type == 1)
            {
                type = mod.ProjectileType("TrueNightArrow");
            }
			Vector2 velVect = new Vector2(speedX, speedY);
			Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-9, 9)));
			int f = Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0, 0);
			Main.projectile[f].noDropItem = true;
			int a =Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			Main.projectile[a].noDropItem = true;
            return false;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 0);
		} 
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Artemis", 1);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 3);
			recipe.AddIngredient(ItemID.SoulofSight, 3);
			recipe.AddIngredient(ItemID.SoulofMight, 3);
			recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
