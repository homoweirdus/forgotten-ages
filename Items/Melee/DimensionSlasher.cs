using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ForgottenMemories.Items.Melee
{
	public class DimensionSlasher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 475;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1800000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 5f;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Dragon's Tongue");
      Tooltip.SetDefault("Striking an enemy with the blade will unleash explosive dragon spit \nReduces enemy defense to near 0 and causes them to melt");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForcedPride", 1);
			recipe.AddIngredient(null, "SolarBlade", 1);
			recipe.AddIngredient(null, "ObliterationBlade", 1);
			recipe.AddIngredient(null, "CosmodiumBar", 16);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.Next(4) == 0)
			{
				float sX = 0f;
				float sY = -3f;
				sX += (float)Main.rand.Next(-30, 31) * 0.2f;
				sY += (float)Main.rand.Next(-61, 0) * 0.2f;
				Projectile.NewProjectile(target.Center.X, target.Center.Y, sX, sY, mod.ProjectileType("DragonSpit"), damage, knockback, player.whoAmI, 0f, 0f);
			}
            target.AddBuff(69, 1800, false);
			target.AddBuff(203, 1800, false);
			target.AddBuff(189, 1800, false);
			target.AddBuff(24, 1800, false);
			target.AddBuff(mod.BuffType("DragonInferno"), 1800, false);
        }
	}
}
