using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence 
{
	public class CrimtaneStabber : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crimtane Stabber";
			item.damage = 16;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 3;
			item.knockBack = 1;
			item.value = 15000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.toolTip = "Executes enemies under 40 life with a blood explosion";
			item.useTurn = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 10);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (target.life <= 40)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BloodBoom"), 30, 0f, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BloodBoom"), 30, 0f, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BloodBoom"), 30, 0f, player.whoAmI, 0f, 0f);
            }
        }
	}
}