using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class Incinerator : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Devil's Flame";
			item.damage = 35;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Incinerates enemies";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
            item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("redflame");
			item.shootSpeed = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FieryGreatsword, 1);
			recipe.AddRecipeGroup("AnyPhaseblade");
			recipe.AddIngredient(ItemID.LavaBucket, 5);
			recipe.AddIngredient(null, "ExterminationCrystal", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
			}
		}

	}
}
