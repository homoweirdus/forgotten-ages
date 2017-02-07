using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Chaotic
{

    public class ChaoticBlade : ModItem
    {

        public override void SetDefaults()
        {

            item.name = "Chaotic Blade";
            item.damage = 62;
            item.crit = 8;
            item.melee = true;
            item.knockBack = 6;
            item.autoReuse = false;
            item.useTurn = true;
            item.width = 46;
            item.height = 48;
            item.useTime = 50;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.value = 138000;
			item.rare = 4;
			item.shoot = 280;
			item.shootSpeed = 10;
			item.autoReuse = true;
			item.useTurn = true;

        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(69, 360, false);
            }
        }
		
		public static void MeleeEffects(Item item, Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 228);
			}
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChaoticBar", 15);
            recipe.AddTile(26);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }



    }

}