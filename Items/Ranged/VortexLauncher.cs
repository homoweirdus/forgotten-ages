using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.Ranged
{
	public class VortexLauncher : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.RocketLauncher);

			item.damage = 92;
			item.ranged = true;
			item.width = 29;
			item.height = 24;


			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = 10000;
			item.rare = 10;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			//item.shoot = 134;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Rocket;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vortex Launcher");
      Tooltip.SetDefault("Causes normal rockets to split into 5 weaker rockets midair \nHas a chance to instead fire 2 homing vortex rockets\n66% chance not to consume ammo");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			if (Main.rand.Next(3) == 0)
			{
				int p = Projectile.NewProjectile(position.X, position.Y, sX+2f, sY+2f, 616, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, sX-2f, sY-2f, 616, damage, knockBack, player.whoAmI);
			}
			else
			{
				int k = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[k].GetGlobalProjectile<Info>(mod).Split = true;
				Main.projectile[k].timeLeft = 25;
			}
			return false;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3456, 18);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}
		
		public override bool ConsumeAmmo(Player player)
	    {
	    	if (Main.rand.Next(0, 100) <= 66)
			{
	    		return false;
			}
	    	return true;
	    }
	}
}
