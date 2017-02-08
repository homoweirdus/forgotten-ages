using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence 
{
	public class DemonStabber : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Demon Stabber";
			item.damage = 17;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 3;
			item.knockBack = 1;
			item.value = 15000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.toolTip = "Hitting an enemy has a chance to explode into corruption gas";
			item.useTurn = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 10);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BBloodBoom"), 30, 0f, player.whoAmI, 0f, 0f);
            }
        }
	}
}