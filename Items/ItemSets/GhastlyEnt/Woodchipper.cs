using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt {
public class Woodchipper : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Wood Chipper";
        item.damage = 15;
        item.ranged = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 34;
        item.useAnimation = 34;
		item.UseSound = SoundID.Item36;
        item.useStyle = 5;
        item.knockBack = 3;
        item.value = 10000;
        item.rare = 1;
        item.autoReuse = true;
		item.toolTip = "Fires a bullet along with woodchips";
        item.shoot = 10; 
		item.shootSpeed = 7f;
		item.useAmmo = AmmoID.Bullet;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        int amountOfProjectiles = 3;
        for (int i = 0; i < amountOfProjectiles; ++i)
        {
            float sX = speedX;
            float sY = speedY;
            sX += (float)Main.rand.Next(-60, 61) * 0.03f;
            sY += (float)Main.rand.Next(-60, 61) * 0.03f;
            Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("Woodchip"), damage / 2, knockBack, player.whoAmI);
        }
        return true;
    }
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}