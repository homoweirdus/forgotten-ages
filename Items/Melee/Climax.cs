using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class Climax : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Climax";
			item.damage = 298;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Can absorb the power of other blades";
			item.useTime = 40;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("climaxbolt");
			item.shootSpeed = 10;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 63);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3459, 5);
			recipe.AddIngredient(3457, 5);
			recipe.AddIngredient(3458, 5);
			recipe.AddIngredient(3456, 5);
			recipe.AddIngredient(3467, 5);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
