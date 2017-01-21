using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged {
public class LightningChainblaster : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Lightning Chainblaster";
        item.damage = 70;
        item.ranged = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 8;
        item.useAnimation = 8;
        item.useStyle = 5;
        item.knockBack = 1;
        item.value = 200000;
        item.rare = 5;
        item.UseSound = SoundID.Item41;
        item.autoReuse = true;
		item.shoot = ProjectileID.Bullet;
		item.shootSpeed = 10f;
		item.noMelee = true;
		item.useAmmo =  AmmoID.Bullet;
    }
	
	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(null, "LaserCannon", 1);
		recipe.AddIngredient(ItemID.ChainGun, 1);
		recipe.AddIngredient(3456, 18);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.SetResult(this);
		recipe.AddRecipe();
	}
	
	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-7, 0);
	}
	
	public override bool ConsumeAmmo(Player player)
	{
		if (Main.rand.Next(3) == 0)
		{
			return true;
		}
		else
		{
		return false;
		}
	
	}
	
	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	{
		if (Main.rand.Next(5) == 0)
		{
		float sX = speedX;
        float sY = speedY;
        sX += (float)Main.rand.Next(-60, 61) * 0.03f;
        sY += (float)Main.rand.Next(-60, 61) * 0.03f;
        Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("ChainLightning"), damage, knockBack, player.whoAmI);
		}
		
		float spX = speedX;
        float spY = speedY;
        spX += (float)Main.rand.Next(-60, 61) * 0.02f;
        spY += (float)Main.rand.Next(-60, 61) * 0.02f;
        Projectile.NewProjectile(position.X, position.Y, spX, spY, type, damage, knockBack, player.whoAmI);
				
			return true;
	}
}}