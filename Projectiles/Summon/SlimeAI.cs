using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace ForgottenMemories.Projectiles.Summon
{
	//copy-pasted from examplemod
	public abstract class PirateAI : Minion
	{
		protected float idleAccel = 0.05f;
		protected float spacingMult = 1f;
		protected float viewDist = 400f;
		protected float chaseDist = 200f;
		protected float chaseAccel = 6f;
		protected float inertia = 40f;
		protected float shootCool;
		protected float shootSpeed;
		protected int shoot;

		public override void Behavior()
		{
			
		}
	}
}