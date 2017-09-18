using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt {
public class LivingTreeSword : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 52;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 30;
        item.useAnimation = 15;
        item.useStyle = 1;
        item.knockBack = 7.5f;
        item.value = 27000;
        item.rare = 2;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;

		item.shoot = mod.ProjectileType("SapBallFriendly");
		item.shootSpeed = 12f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Living Tree Sword");
      Tooltip.SetDefault("Swings Slow, but hits heavily, fires a splitting sap ball");
    }

	

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
