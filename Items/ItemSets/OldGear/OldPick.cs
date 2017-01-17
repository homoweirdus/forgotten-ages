using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.OldGear {
public class OldPick : ModItem
{
    public override void SetDefaults()
    {
		item.name = "Ancient Pickaxe";
        item.damage = 5;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 12;
        item.useAnimation = 24;
        item.useStyle = 1;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.pick = 35;
    }
	
	public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 11);
				Main.dust[dust2].scale = 1.2f;
				Main.dust[dust2].noGravity = true;
			}
		}
}}