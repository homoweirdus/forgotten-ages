using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class SoaringDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.5f;
			dust.frame = new Rectangle(0, 0, 6, 6);
		}
		
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity / 2;
			dust.rotation += dust.velocity.X / 2;
			dust.scale -= 0.1f;
			if (dust.scale < 0.2f)
			{
				dust.active = false;
			}
			else
			{
				float strength = dust.scale / 2f;
				Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 255f * 0.5f * strength, dust.color.G / 255f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
			}
			return false;
		}
	}
}