using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class MuramisianSpectre : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 70;
			item.melee = true;
			item.width = 62;
			item.height = 62;

			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Muramisian Spectre");
      Tooltip.SetDefault("Fires spectre bolts on hit");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
				Main.dust[dust2].noGravity = true;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Muramasa, 1);
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddIngredient(null,"SpiritflameChunk", 12);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			float sXv = player.velocity.X * 2f;
			float sYv = player.velocity.Y * 2f;
			float sX = (float)Main.rand.Next(-50, 50) * 0.1f;
			float sY = (float)Main.rand.Next(-50, 50) * 0.1f;
			Projectile.NewProjectile(player.Center.X, player.Center.Y, sX + sXv, sY + sYv, mod.ProjectileType("SpectreWave"), damage, 0f, player.whoAmI, 0f, 0f);
        }	
	}
}
