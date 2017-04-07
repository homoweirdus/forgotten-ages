using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace ForgottenMemories
{
    public static class Config
    {
        public static bool VanillaBalance = true;
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Beyond The Forgotten Ages.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            bool success = ReadConfig();

            if(!success)
            {
                ErrorLogger.Log("Failed to read Beyond The Forgotten Ages' config file! Recreating config...");
                CreateConfig();
            }
        }

        static bool ReadConfig()
        {
            if(Configuration.Load())
            {
                Configuration.Get("VanillaBalance", ref VanillaBalance);
                return true;
            }
            return false;
        }

        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("VanillaBalance", VanillaBalance);
            Configuration.Save();
        }
    }
}