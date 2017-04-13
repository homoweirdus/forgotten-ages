using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Town
{
	public class Warper : ModNPC
	{
		
		public override bool Autoload(ref string name, ref string texture, ref string[] altTextures)
		{
			name = "Warper";
			altTextures = new string[] { "ForgottenMemories/NPCs/Town/Warper"};
			return mod.Properties.Autoload;
		}
		public override void SetDefaults()
		{
			npc.name = "Warper";
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 25;
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			animationType = NPCID.Dryad;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            //if (NPC.downedBoss2)
           // {
            //    return true;
            //}
            return false;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Lucy";
				case 1:
					return "Stephanie";
				case 2:
					return "Luna";
                case 3:
                    return "Delilah";
                case 4:
                    return "Julie";
                default:
                    return "Carol";
			}
		}

		public override string GetChat()
		{
			int wizard = NPC.FindFirstNPC(NPCID.Demolitionist);
			if (wizard >= 0 && Main.rand.Next(4) == 0)
			{
				return "I remember when " + Main.npc[wizard].displayName + " was a little kid... how time flies.";
			}
			if (WorldGen.crimson && Main.rand.Next(4) == 0)
			{
				return "I was exploring the Crimson, then i saw this strange Eye... Then there were about 495 of them!";
			}
			switch (Main.rand.Next(2))
			{
				case 0:
                    return "I promise won't burn down your house, but I can't guarantee that there will be no accidents";
				default:
					return "Fire is great, isn't it!";
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
            shop.item[nextSlot].SetDefaults(3380); //sturdy fossil
			nextSlot++;
			if (NPC.downedMoonlord)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DeepspaceSigil"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 14;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 13;
			randExtraCooldown = 1;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 3379;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 15f;
			randomOffset = 2f;
		}
	}
}