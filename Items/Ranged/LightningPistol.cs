using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged {
public class LightningPistol : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Lightning Pistol";
        item.damage = 8;
        item.ranged = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 22;
        item.useAnimation = 22;
        item.useStyle = 5;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 2;
        item.UseSound = SoundID.Item11;
        item.autoReuse = true;
		item.shoot = ProjectileID.Bullet;
		item.shootSpeed = 10f;
		item.noMelee = true;
		item.useAmmo =  AmmoID.Bullet;
    }
	
	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.FlintlockPistol, 1);
		recipe.AddIngredient(null, "VisionCrystal", 3);
		recipe.AddIngredient(ItemID.MeteoriteBar, 15);
		recipe.AddTile(TileID.Anvils);
		recipe.SetResult(this);
		recipe.AddRecipe();
	}
	
	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	{
		float sX = speedX;
        float sY = speedY;
        sX += (float)Main.rand.Next(-60, 61) * 0.03f;
        sY += (float)Main.rand.Next(-60, 61) * 0.03f;
        Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("PistolLightning"), damage, knockBack, player.whoAmI);
				
			return true;
	}
}}