using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories
{
	public class ForgottenMemories : Mod 
	{
		public ForgottenMemories()

		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadBackgrounds = true,
				AutoloadSounds = true,
				AutoloadGores = true
			};
		}

		public override void Load()
		{
			Config.Load();
		}
		
		const int ShakeLength = 5;
		int ShakeCount = 0;
		float previousRotation = 0;
		float targetRotation = 0;
		float previousOffsetX = 0;
		float previousOffsetY = 0;
		float targetOffsetX = 0;
		float targetOffsetY = 0;
		
		public override Matrix ModifyTransformMatrix(Matrix Transform)
		{
			if (!Main.gameMenu)
			{
				TGEMWorld world = GetModWorld<TGEMWorld>();
				if (TGEMWorld.TremorTime > 0)
				{
					if (TGEMWorld.TremorTime % ShakeLength == 0)
					{
						ShakeCount = 0;
						previousRotation = targetRotation;
						previousOffsetX = targetOffsetX;
						previousOffsetY = targetOffsetY;
						targetRotation = (Main.rand.NextFloat() - .5f) * MathHelper.ToRadians(7);
						targetOffsetX = Main.rand.Next(60) - 30;
						targetOffsetY = Main.rand.Next(40) - 20;
						if (TGEMWorld.TremorTime == ShakeLength)
						{
							targetRotation = 0;
							targetOffsetX = 0;
							targetOffsetY = 0;
						}
					}
					float transX = Main.screenWidth / 2;
					float transY = Main.screenHeight / 2;

					float lerp = (float)(ShakeCount) / ShakeLength;
					float rotation = MathHelper.Lerp(previousRotation, targetRotation, lerp);
					float offsetX = MathHelper.Lerp(previousOffsetX, targetOffsetX, lerp);
					float offsetY = MathHelper.Lerp(previousOffsetY, targetOffsetY, lerp);

					TGEMWorld.TremorTime--;
					ShakeCount++;


					return Transform
						* Matrix.CreateTranslation(-transX, -transY, 0f)
						* Matrix.CreateRotationZ(rotation)
						* Matrix.CreateTranslation(transX, transY, 0f)
						* Matrix.CreateTranslation(offsetX, offsetY, 0f);
					//Matrix.CreateFromAxisAngle(new Vector3(Main.screenWidth / 2, Main.screenHeight / 2, 0f), .2f);
					//Matrix.CreateRotationZ(MathHelper.ToRadians(30));
				}
			}
			return Transform;
		}
		
		public override void UpdateMusic(ref int music)
        {
            if (Main.invasionX == Main.spawnTileX && TGEMWorld.forestInvasionUp)
            {
                music = 12;
			}
        }
		
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + (" Phaseblade"), new int[]
			{
				198,
				199,
				200,
				201,
				202,
				203
			});
			RecipeGroup.RegisterGroup("AnyPhaseblade", group);
			
			RecipeGroup wood = new RecipeGroup (() => Lang.misc[37] + (" Wood"), new int[]
			{
				9,
				620,
				619,
				911,
				621,
				2503,
				2504,
				2260,
				1729
			});
			RecipeGroup.RegisterGroup("AnyWood", wood);
		}
		
		public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                // To include a description:
                bossChecklist.Call("AddBossWithInfo", "Ghastly Ent", 3.2f, (Func<bool>)(() => TGEMWorld.downedGhastlyEnt), "Use a [i:" + ItemType("AncientLog") + "] that drops uncommonly from Tree Men post-Eye of Cthulhu");
				bossChecklist.Call("AddBossWithInfo", "Arterius", 6.3f, (Func<bool>)(() => TGEMWorld.downedArterius), "Use a [i:" + ItemType("BloodClot") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Titan Rock", 6.9f, (Func<bool>)(() => TGEMWorld.downedTitanRock), "Use a [i:" + ItemType("anomalydetector") + "]");
			}
        }

		
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HermesBoots, 1);
			recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
			recipe.AddIngredient(null,"WaterShard", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(863, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FlurryBoots, 1);
			recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
			recipe.AddIngredient(null,"WaterShard", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(863, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Leather, 14);
			recipe.AddIngredient(ItemID.Cobweb, 10);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(159, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(158, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(158, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(65, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(65, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(3380, 6);
			recipe.AddIngredient(169, 80);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(857, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(3380, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(934, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Gatligator, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LeadBar, 10);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.Gatligator, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FlintlockPistol, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Revolver, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Rally, 1);
			recipe.AddIngredient(null, "WaterShard", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Code1, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Code1, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.Code2, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ShroomiteBar, 18);
			recipe.AddIngredient(ItemID.BeetleHusk, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.PulseBow, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(18);
            recipe.SetResult(259, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Starfury, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3458, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3065, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3456, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(1553, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(3292, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3458, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3389, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(662, 40);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3458, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3063, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.RocketLauncher, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3456, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3546, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BlizzardStaff, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3457, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3570, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HeatRay, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3457, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3541, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.QueenSpiderStaff, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3459, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3569, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(1572, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(3459, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(3571, 1);
            recipe.AddRecipe();
		}
	}
}
