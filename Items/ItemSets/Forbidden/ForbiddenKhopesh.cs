using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenKhopesh : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 110;
			item.melee = true;
			item.width = 96;
			item.height = 88;

			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 600000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 5f;
			item.useTurn = true;
		}


    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Khopesh");
      Tooltip.SetDefault("Right clicking will swing the sword slower and disarm hit enemies");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(3261, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 1;
				item.useTime = 26;
				item.useAnimation = 26;
				item.damage = 130;
			}
			else
			{
				item.useStyle = 1;
				item.useTime = 16;
				item.useAnimation = 16;
				item.damage = 110;
			}
			return base.CanUseItem(player);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse == 2)
			{
				target.AddBuff(mod.BuffType("Disarmed"), 120, false);
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 32, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity.X += player.direction * 2f;
				Main.dust[dust].velocity.Y += 0.2f;
			}
		}
	}
}
