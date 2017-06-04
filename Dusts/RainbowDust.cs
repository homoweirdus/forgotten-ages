using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class RainbowDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.scale *= 0.5f;
			dust.alpha = 200;
			dust.frame = new Rectangle(0, 0, 10, 10);
		}
		
		public override bool Update(Dust dust)
		{
            float num2 = dust.scale * 0.6f;
			dust.color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
			Lighting.AddLight((int) ((double) dust.position.X), (int) ((double) dust.position.Y), num2 * Main.DiscoR/5, num2 * Main.DiscoG/5, num2 * Main.DiscoB/5);
			
			return true;
		}
	}
}