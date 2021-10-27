using UnityEngine;
using UnityModManagerNet;

namespace AdofaiUtils
{
    public class Settings : UnityModManager.ModSettings, IDrawable
    {
        [Draw("음악 시간 설정", Collapsible = true)] public PlayTimeSettings PSettings = new PlayTimeSettings();

        [Draw("진행도 설정", Collapsible = true)] public ProgressSettings ProgressSettings = new ProgressSettings();

        [Draw("정확도 설정", Collapsible = true)] public AccuracySettings AccuracySettings = new AccuracySettings();
        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void OnChange()
        {
            
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            GUILayout.Label("텍스트 설정");
            GUILayout.Label("플레이 타임 텍스트형식");
            PSettings.TextTemplate = GUILayout.TextField(PSettings.TextTemplate);
            PSettings.NotPlaying = GUILayout.TextField(PSettings.NotPlaying);
            GUILayout.Label("진행도 텍스트 형식");
            ProgressSettings.TextTemplate = GUILayout.TextField(ProgressSettings.TextTemplate);
            ProgressSettings.NotPlaying = GUILayout.TextField(ProgressSettings.NotPlaying);
            GUILayout.Label("정확도 텍스트 형식");
            AccuracySettings.TextTemplate = GUILayout.TextField(AccuracySettings.TextTemplate);
            AccuracySettings.NotPlaying = GUILayout.TextField(AccuracySettings.NotPlaying);
            Main.Settings.Draw(modEntry);
        }

        public void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Main.Settings.Save(modEntry);
        }
    }
}