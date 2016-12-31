using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
    public class DamnationStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Damnation Staff";
            item.damage = 60;
            item.magic = true;
            item.mana = 8;
            item.width = 25;
            item.height = 26;
            item.toolTip = "Fires an exploding orb";
            item.useTime = 16;
			item.UseSound = SoundID.Item20;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            Item.staff[item.type] = true;
            item.value = 10000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("hellorb");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
	}
}