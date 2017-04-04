using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Ascension
{
    public class CosmosHunter : ModNPC
    {
        int counter = 0;
        public override void SetDefaults()
        {
            npc.name = "Cosmos Hunter";
            npc.displayName = "Cosmic Hunter";
            npc.width = 52;
            npc.height = 48;
            npc.damage = 125;
            npc.defense = 70;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 6000f;
            npc.knockBackResist = .20f;
            Main.npcFrameCount[npc.type] = 3;
           
        }

       // public override float CanSpawn(NPCSpawnInfo spawnInfo)
       // {
       //     return spawnInfo.spawnTileY > Main.rockLayer && spawnInfo.player.ZoneJungle ? 0.2f : 0f;
       // }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        
        public override void AI()
        {
            if (Main.rand.Next(3) == 1)
            {
                counter++;
            }
            counter++;
            npc.spriteDirection = npc.direction;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (counter % 100 < 12 && counter % 4 == 0)
            {
                Vector2 direction9 = player.Center - npc.Center;
                direction9.Normalize();
                direction9 *= 15f;
                   int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction9.X , direction9.Y, 577, npc.damage, 1, npc.target, 0, 0);
                Projectile newProj = Main.projectile[proj];
                newProj.tileCollide = false;
            }
            if (counter % 2 == 0)
            {
                if (player.Center.X > npc.Center.X + 50 && npc.velocity.X < 10)
                {
                    npc.velocity.X++;
                }
                else if (player.Center.X < npc.Center.X - 50 && npc.velocity.X > -10)
                {
                    npc.velocity.X--;
                }
            }
          /*  if (counter % 400 == 251)
            {
                npc.velocity.Y = 0;
            }*/
            if (counter % 400 < 225)
            {
                npc.noTileCollide = true;
                if (counter % 3 == 0)
                {
                    npc.velocity.Y -= 1;
                }
            }
            else
            {
                npc.noTileCollide = false;
            }
            if (npc.velocity.Y > 1)
            {
                npc.noTileCollide = false;
            }
           /* else if (counter % 400 < 230 && counter % 400 > 225)
            {
                npc.velocity.Y += 2;
            }*/
        }
        
    }
}
