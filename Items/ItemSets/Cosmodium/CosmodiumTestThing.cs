using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumTestThing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Test item";
            item.toolTip = "Launches a random projectile";
            item.damage = 243;
            item.magic = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 1;
            item.useAnimation = 2;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CosmodiumBolt");
            item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
          
          
            int proj2 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Main.rand.Next(714), damage, knockBack, player.whoAmI);
            Projectile newProj2 = Main.projectile[proj2];
            newProj2.hostile = false;
            newProj2.friendly = true;
            newProj2.timeLeft = 300;
            return false;
        }
       

    }
}
