using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Summon
{
	public class MechanicsHammer : ModItem
	{
		public override void SetDefaults()
		{
		item.CloneDefaults(ItemID.QueenSpiderStaff); 

			item.damage = 20;  
			item.mana = 13;   
			item.width = 40;
			item.height = 40;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
			ProjectileID.Sets.TurretFeature[item.shoot] = true;
            item.rare = 3;
            item.knockBack = 2.5f;
			item.UseSound = SoundID.Item25;


            item.shoot = mod.ProjectileType("MechanicalTurret");
			item.shootSpeed = 0f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mechanics Hammer");
      Tooltip.SetDefault("Summons a stationary Turret\n'Gotta move that gear up'");
    }


		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for(int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == item.shoot && p.owner == player.whoAmI) 
				{
					p.active = false;
				}
			}
            Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            position = value18;
            return true;
        }

	}
}
