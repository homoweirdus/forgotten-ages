using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.Info;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class TitaniumTome : ModItem
    {
		int counter = 0;
        public override void SetDefaults()
        {
            item.name = "Titanium Tome";
            item.damage = 44;
            item.magic = true;
            item.mana = 8;
            item.width = 14;
            item.height = 16;
            item.toolTip = "Summons a bolt of energy from the sky that splits into more bolts";
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = 69000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = (126);
            item.shootSpeed = 17f;
			item.UseSound = SoundID.Item20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			mouse.X += Main.rand.Next(-20, 21);
			float sX = 0;
			float sY = 25;
			sX += (float)Main.rand.Next(-10, 10) * 0.2f;
			sY += (float)Main.rand.Next(-10, 30) * 0.2f;
			int proj = Projectile.NewProjectile(mouse.X, (position.Y-1000), sX, sY, type, damage, knockBack, player.whoAmI);
			Main.projectile[proj].GetModInfo<Info>(mod).Titanium = true;
			Main.projectile[proj].penetrate = 1;
			return false;
		}
    }
}