using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Necro
{
	public class NecroScythe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Reaper's Scythe";
			item.damage = 47;
			item.melee = true;
			item.width = 58;
			item.height = 52;
			item.toolTip = "Tears through souls.";
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6.5f;
			item.value = 138000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecroflameSickleProj");
			item.shootSpeed = 10f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(153, 360, false);
			}
		}
	}
}