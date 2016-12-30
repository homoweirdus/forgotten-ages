using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items
{
	public class Climax : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Climax";
			item.damage = 298;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Can absorb the power of other blades";
			item.useTime = 40;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("climaxbolt");
			item.shootSpeed = 10;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 63);
				Main.dust[dust].scale = 1.5f;
			}
		}
}}
