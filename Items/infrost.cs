using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items
{
	public class infrost : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Serial Inferost";
			item.damage = 50;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.toolTip = "You should be frozen just by touching this thing!";
			item.useTime = 48;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("infrost");
			item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Frostbrand, 1);
			recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(ItemID.FrostCore, 3);
			recipe.AddIngredient(ItemID.SnowBlock, 100);
			recipe.AddIngredient(ItemID.IceBlock, 250);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 67);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust2].scale = 1.2f;
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) < 2)
			{
			target.AddBuff(BuffID.Frostburn, 60);
			}
			if (Main.rand.Next(100) < 99)
			{
				target.AddBuff(BuffID.Frozen, 10);
			}
		
		}
	}
}
