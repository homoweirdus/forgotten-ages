using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee {
public class IchorLance : ModItem
{


	public override void SetDefaults()
	{
		item.name = "Ichor Lance";
		item.width = 65;  //The width of the .png file in pixels divided by 2.
		item.damage = 250;  //Keep this reasonable please.
		item.melee = true;  //Dictates whether this is a melee-class weapon.
		item.noMelee = true;
		item.useTurn = true;
		item.noUseGraphic = true;
		item.useAnimation = 18;
		item.toolTip = "delet this no but someone add a recipe";
		item.useStyle = 5;
		item.useTime = 18;
		item.knockBack = 9.5f;  //Ranges from 1 to 9.
		item.UseSound = SoundID.Item1;
		item.autoReuse = false;  //Dictates whether the weapon can be "auto-fired".
		item.height = 96;  //The height of the .png file in pixels divided by 2.
		item.maxStack = 1;
		item.value = 10000000;  //Value is calculated in copper coins.
		item.rare = 10;  //Ranges from 1 to 11.
		item.shoot = mod.ProjectileType("IchorLanceProjectile");
		item.shootSpeed = 10f;
	}
}}
