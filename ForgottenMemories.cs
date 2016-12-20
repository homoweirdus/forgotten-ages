using Terraria.ModLoader;

namespace ForgottenMemories
{
	class ForgottenMemories : Mod
	{
		public ForgottenMemories()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
