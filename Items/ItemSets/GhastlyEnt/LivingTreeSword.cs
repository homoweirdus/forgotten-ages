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
		item.name = "Living Tree Sword";
        item.damage = 30;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 40;
        item.useAnimation = 40;
        item.useStyle = 1;
        item.knockBack = 7.5f;
        item.value = 10000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.toolTip = "Swings Slow, but hits heavily";
        item.useTurn = true;
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