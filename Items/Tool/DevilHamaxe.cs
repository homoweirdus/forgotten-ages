using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Tool {
public class DevilHamaxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 17;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 11;
        item.useAnimation = 11;
        item.useStyle = 1;
        item.knockBack = 1.5f;
        item.value = 14000;
        item.rare = 2;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.axe = 20;
		item.hammer = 60;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Devil Hamaxe");
      Tooltip.SetDefault("");
    }

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DevilFlame", 14);
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
}}
