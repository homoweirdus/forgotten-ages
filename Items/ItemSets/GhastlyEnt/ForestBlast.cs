using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt {
public class ForestBlast : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 20;
        item.magic = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 28;
        item.useAnimation = 28;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 27000;
        item.rare = 2;
        item.UseSound = SoundID.Item20;
        item.autoReuse = true;
		item.shoot = mod.ProjectileType("LeafnadoFriendly");
		item.shootSpeed = 10f;
		item.mana = 10;

		item.noMelee = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forest Blast");
      Tooltip.SetDefault("Fires a spread of leafnados");
    }

	
	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = Main.rand.Next(2, 5);
			for (int i = 0; i < amountOfProjectiles; i++)
			{
				float spX = speedX;
				float spY = speedY;
				spX += (float)Main.rand.Next(-40, 41) * 0.05f;
				spY += (float)Main.rand.Next(-40, 41) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, spX, spY, type, damage, knockBack, player.whoAmI);
			}
			
			return false;
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
