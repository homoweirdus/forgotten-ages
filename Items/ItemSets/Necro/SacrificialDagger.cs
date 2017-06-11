using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class SacrificialDaggerP : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.width = 22;
			projectile.height = 22;
			projectile.penetrate = 6;
			aiType = ProjectileID.Shuriken;
			projectile.ignoreWater = true;
			projectile.timeLeft = 6000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sacrificial Dagger");
		}
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("SacrificialDagger"));
			}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(153, 360, false);
			}
		}

	}

	public class SacrificialDagger : ModItem
	{

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.damage = 38;
		}
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sacrificial Dagger");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NecroBar", 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}
	}
}
