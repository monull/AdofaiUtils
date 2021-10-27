using System.Reflection;
using AdofaiUtils.Patch;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace AdofaiUtils
{
    internal static class Main
    {
        public static Text text;
        public static ProgressText ptext;
        public static AccuracyText atext;
        private static Harmony _harmony;
        private static UnityModManager.ModEntry _mod;
        internal static Settings Settings { get; private set; }
        internal static bool IsEnabled;

        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            _mod = modEntry;
            _mod.OnToggle = OnToggle;
            Settings = UnityModManager.ModSettings.Load<Settings>(modEntry);
            _mod.OnGUI = Settings.OnGUI;
            _mod.OnSaveGUI = Settings.OnSaveGUI;

            return true;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            IsEnabled = value;

            if (value)
            {
                StartTweaks();
            }
            else
            {
                StopTweaks();
            }

            return true;
        }

        private static void StartTweaks()
        {
            _harmony = new Harmony(_mod.Info.Id);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            text = new GameObject().AddComponent<Text>();
            Object.DontDestroyOnLoad(text);
            ptext = new GameObject().AddComponent<ProgressText>();
            Object.DontDestroyOnLoad(ptext);
            atext = new GameObject().AddComponent<AccuracyText>();
            Object.DontDestroyOnLoad(atext);
            
        }

        private static bool StopTweaks()
        {
            _harmony.UnpatchAll(_mod.Info.Id);
            _harmony = null;
            
            Object.DestroyImmediate(text);
            text = null;
            Object.DestroyImmediate(ptext);
            ptext = null;
            Object.DestroyImmediate(atext);
            atext = null;
            
            return true;
        }
    }
}