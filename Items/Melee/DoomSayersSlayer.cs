using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ForgottenMemories.Items.Melee
{
	public class DoomSayersSlayer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Doom Sayer's Slayer";
			item.damage = 200;
			item.melee = true;
			item.width = 82;
			item.height = 82;
			item.toolTip = "Fires a homing bolt of Reality Fury \nRight-Clicking fires bolts of Despair, Dread, and Anger \nOnly usable if Thorium is installed";
			item.useTime = 16;
			item.useAnimation = 16;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				item.useStyle = 1;
			}
			item.knockBack = 6;
			item.value = 637500;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DoomBeam");
			item.shootSpeed = 10;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
				Main.dust[dust2].scale = 0.5f;
				Main.dust[dust2].noGravity = true;
				int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust3].scale = 0.5f;
				Main.dust[dust3].noGravity = true;
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(255, 127, 0);
                }
            }
        }
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void AddRecipes()
        {
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence"));
				recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence"));
				recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence"));
				recipe.AddTile(412);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 newVect = new Vector2(speedX, speedY);
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.Pi / 16);
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.Pi / -16);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect.X, newVect.Y, mod.ProjectileType("AngerBolt"), damage/2, knockBack, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect2.X, newVect2.Y, mod.ProjectileType("DespairBolt"), damage/2, knockBack, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect3.X, newVect3.Y, mod.ProjectileType("DreadBolt"), damage/2, knockBack, player.whoAmI, 0f, 0f);
				return false;
			}
			
			else
			{
				return true;
			}
		}
	}
}
