using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence 
{
	public class PowerKnife : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 12;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.width = 22;
			item.height = 22;

			item.useTime = 37;
			item.useAnimation = 37;
			item.useStyle = 1;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("PowerKnifeProj");
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.scale = 1f;
			item.value = 3;
			item.rare = 1;
			item.autoReuse = true;
			item.consumable = true;
			item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glittering Knives");
      Tooltip.SetDefault("Throws multiple knives");
    }



		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 3;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.02f;
				sY += (float)Main.rand.Next(-60, 61) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 1);
			recipe.AddIngredient(null, "OpticBar", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 111);
			recipe.AddRecipe();
		}
	}}
