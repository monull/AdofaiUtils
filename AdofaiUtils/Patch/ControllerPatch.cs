using System;
using HarmonyLib;
using UnityEngine;

namespace AdofaiUtils.Patch
{
    public class Text : MonoBehaviour
    {
        public static string Content = "";

        private void OnGUI()
        {
            if (Main.Settings.PSettings.TextShadow > 0)
            {
                GUIStyle shadow = new GUIStyle();
                shadow.fontSize = Main.Settings.PSettings.TextSize;
                shadow.font = RDString.GetFontDataForLanguage(SystemLanguage.Korean).font;
                shadow.normal.textColor = Color.black.WithAlpha((float) Main.Settings.PSettings.TextShadow / 100);
                
                GUI.Label(new Rect(Main.Settings.PSettings.PositionX + 12, Main.Settings.PSettings.PositionY - 8, Screen.width, Screen.height), Content, shadow);
            }
            GUIStyle style = new GUIStyle();
            style.fontSize = Main.Settings.PSettings.TextSize;
            style.font = RDString.GetFontDataForLanguage(RDString.language).font;
            style.normal.textColor = Color.white;
            
            GUI.Label(new Rect(Main.Settings.PSettings.PositionX + 12, Main.Settings.PSettings.PositionY - 10, Screen.width, Screen.height), Content, style);
        }
    }
    public class ProgressText : MonoBehaviour
    {
        public static string Content = "";

        private void OnGUI()
        {
            if (Main.Settings.ProgressSettings.TextShadow > 0)
            {
                GUIStyle shadow = new GUIStyle();
                shadow.fontSize = Main.Settings.ProgressSettings.TextSize;
                shadow.font = RDString.GetFontDataForLanguage(SystemLanguage.Korean).font;
                shadow.normal.textColor = Color.black.WithAlpha((float) Main.Settings.ProgressSettings.TextShadow / 100);
                
                GUI.Label(new Rect(Main.Settings.ProgressSettings.PositionX + 12, Main.Settings.ProgressSettings.PositionY - 8, Screen.width, Screen.height), Content, shadow);
            }
            GUIStyle style = new GUIStyle();
            style.fontSize = Main.Settings.ProgressSettings.TextSize;
            style.font = RDString.GetFontDataForLanguage(RDString.language).font;
            style.normal.textColor = Color.white;
            
            GUI.Label(new Rect(Main.Settings.ProgressSettings.PositionX + 12, Main.Settings.ProgressSettings.PositionY - 10, Screen.width, Screen.height), Content, style);
        }
    }

    public class AccuracyText : MonoBehaviour
    {
        public static string Content = "";

        private void OnGUI()
        {
            if (Main.Settings.ProgressSettings.TextShadow > 0)
            {
                GUIStyle shadow = new GUIStyle();
                shadow.fontSize = Main.Settings.AccuracySettings.TextSize;
                shadow.font = RDString.GetFontDataForLanguage(SystemLanguage.Korean).font;
                shadow.normal.textColor =
                    Color.black.WithAlpha((float) Main.Settings.AccuracySettings.TextShadow / 100);
                
                GUI.Label(new Rect(Main.Settings.AccuracySettings.PositionX + 12, Main.Settings.AccuracySettings.PositionY - 8, Screen.width, Screen.height), Content, shadow);
            }

            GUIStyle style = new GUIStyle();
            style.fontSize = Main.Settings.AccuracySettings.TextSize;
            style.font = RDString.GetFontDataForLanguage(RDString.language).font;
            style.normal.textColor = Color.white;
            
            GUI.Label(new Rect(Main.Settings.AccuracySettings.PositionX + 12, Main.Settings.AccuracySettings.PositionY - 8, Screen.width, Screen.height), Content, style);
        }
    }
    [HarmonyPatch(typeof(scrController), "PlayerControl_Update")]
    internal static class ChangeText
    {
        private static void Prefix(scrController __instance) {
            if (!scrController.instance.paused && scrConductor.instance.isGameWorld) {
                if (!scrConductor.instance.song.clip) return;
                
                TimeSpan nowt = TimeSpan.FromSeconds(scrConductor.instance.song.time);
                TimeSpan tott = TimeSpan.FromSeconds(scrConductor.instance.song.clip.length);
                Text.Content = Main.Settings.PSettings.TextTemplate
                    .Replace("<NowMinute>", nowt.Minutes.ToString())
                    .Replace("<NowSecond>", nowt.Seconds.ToString("00"))
                    .Replace("<TotalMinute>", tott.Minutes.ToString())
                    .Replace("<TotalSecond>", tott.Seconds.ToString("00"));
                ProgressText.Content =
                    Main.Settings.ProgressSettings.TextTemplate.Replace("<progress>", (__instance.percentComplete * 100).ToString());
                AccuracyText.Content =
                    Main.Settings.AccuracySettings.TextTemplate.Replace("<percent>",
                        (__instance.mistakesManager.percentAcc * 100).ToString());

            }
            else {
                Text.Content = Main.Settings.PSettings.NotPlaying;
                ProgressText.Content = Main.Settings.ProgressSettings.NotPlaying;
                AccuracyText.Content = Main.Settings.AccuracySettings.NotPlaying;
            }
        }
    }

    [HarmonyPatch(typeof(scrController), "FailAction")]
    internal static class ChangeTextOnFail
    {
        private static void Prefix(scrController __instance)
        {
            Text.Content = Main.Settings.PSettings.NotPlaying;
            ProgressText.Content = Main.Settings.ProgressSettings.NotPlaying;
            AccuracyText.Content = Main.Settings.AccuracySettings.NotPlaying;
        }
    }
}