namespace Starwar.Common
{
    using System;
    using System.IO;
    using System.Reflection;
    using Newtonsoft.Json;

    public sealed class Settings
    {
        private const string SettingsFileName = "settings.json";

        public int NumOfEnemiesPerSecond { get; set; }
        public bool ShowDebugInfo { get; set; }
        public bool LiveForever { get; set; }

        public bool FullScreen { get; set; }

        public static readonly Settings Default = new Settings
        {
            LiveForever = false,
            NumOfEnemiesPerSecond = 2,
            ShowDebugInfo = false,
            FullScreen = false
        };

        private static string SettingsFile
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SettingsFileName);
            }
        }

        public static Settings ReadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    var json = File.ReadAllText(SettingsFile);
                    var readSettings = JsonConvert.DeserializeObject<Settings>(json);
                    if (readSettings.NumOfEnemiesPerSecond < 1)
                    {
                        readSettings.NumOfEnemiesPerSecond = Default.NumOfEnemiesPerSecond;
                    }
                    return readSettings;
                }
                catch
                {
                }
            }
            return Default;
        }

        public static void SaveSettings(Settings settings)
        {
            File.WriteAllText(SettingsFile, JsonConvert.SerializeObject(settings));
        }
    }
}
