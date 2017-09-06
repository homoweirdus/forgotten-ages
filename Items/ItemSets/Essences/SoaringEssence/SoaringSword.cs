using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;


namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	public class SoaringSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 45;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("meleestorm");
			item.shootSpeed = 8f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Soaring Skyblade");
      Tooltip.SetDefault("Fires a short ranged projectile");
    }
	
	public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SoaringDust"));
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
		}

		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
