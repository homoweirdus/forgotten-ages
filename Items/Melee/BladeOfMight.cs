using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class BladeOfMight : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Soul Slasher";
			item.damage = 50;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			AddTooltip("Fires a sword beam that flies towards your cursor's location after right-clicking");
			AddTooltip("'Enchanted with the essence of the Destroyer'");
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 500000;
			item.rare = 5;
			item.shoot = mod.ProjectileType("MightBeam");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 29);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
		}
	}
}
