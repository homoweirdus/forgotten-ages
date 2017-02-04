using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Town
{
	public class JohnHammond : ModNPC
	{
		public override bool Autoload(ref string name, ref string texture, ref string[] altTextures)
		{
			name = "Archeologist";
			return mod.Properties.Autoload;
		}

		public override void SetDefaults()
		{
			npc.name = "Archeologist";
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 23;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 20;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			animationType = NPCID.Guide;
		}


		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < Main.player.Length; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == ItemID.AmberMosquito)
						{
							return true;
						}
					}
				}
			}
			return false;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(1))
			{
				case 0:
					return "John Hammond";
			    default:
				    return "John Hammond";
			}
		}

		

		public override string GetChat()
		{
			
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Welcome.. To my house. What, did you expect a dinosaur park or something?";
				case 1:
					return "I died in the book you know?";
			    case 2: 
				    return "Did the aliens kill the dinosaurs to make room for humans?";
				case 3: 
				    return "I have a thing for dinosaurs...";
				case 4: 
				    return "Pfft, what do you mean a meteor killed the dinosaurs? We all know a gigantic tentacle monster destroyed them with eye-beams.";
				case 5: 
				    return "Some people think i managed to make my start from mosquitos. What kind of idiot would think that?";
					
				default:
					return "This is not the fossil seller you are looking for.";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28];
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.Bone;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}