using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items
{
	public class murderblade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Murder blade";
			item.damage = 100;
			item.melee = true;
			item.width = 62;
			item.height = 62;
			item.toolTip = "How are your hands still on?";
			item.useTime = 4;
			item.useAnimation = 4;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);
				Main.dust[dust2].scale = 2.5f;
			}
		}
		
	}
}
