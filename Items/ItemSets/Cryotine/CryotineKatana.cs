using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class CryotineKatana : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cryotine Katana";
			item.damage = 19;
			item.melee = true;
			item.crit = 25;
			item.width = 88;
			item.height = 88;
			item.useTime = 10;
			item.useAnimation = 10;
			item.toolTip = "Inflicts frostburn on hit";
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 168000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 67);
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(BuffID.Frostburn, 180, false);
        }
	}
}
