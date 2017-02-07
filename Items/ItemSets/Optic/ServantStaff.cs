using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Optic
{
    public class ServantStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Servant Staff";
            item.damage = 10;
            item.summon = true;
            item.mana = 10;
            item.width = 42;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            AddTooltip("Summons Cthulhu's Servants to fight");
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2f;
            item.buffType = mod.BuffType("ServantOfCthulhu");
            item.buffTime = 3600;
            item.value = 450000;
            item.rare = 6;
            item.UseSound = SoundID.Item82;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Servant");
            item.shootSpeed = 10f;
        }

        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(1) == 0)
            {
                player.AddBuff(BuffID.Hunter, 2);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OpticBar", 12);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}