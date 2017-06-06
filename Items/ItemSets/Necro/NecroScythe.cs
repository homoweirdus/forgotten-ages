using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class NecroScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 42;
			item.melee = true;
			item.width = 58;
			item.height = 52;

			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 6.5f;
			item.value = 138000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecroflameSickleProj");
			item.shootSpeed = 9f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Reaper's Scythe");
      Tooltip.SetDefault("Tears through souls");
    }

		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
            Vector2 origVect = new Vector2(speedX, speedY);
            Vector2 newVect = origVect.RotatedBy(System.Math.PI / 12);
            Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 12);

            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 0);
            Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI, 0, 0);
            Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			return false;
        }

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(153, 360, false);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NecroBar", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
