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

        public int NumOfLasersPerSecond { get; set; }

        public bool ShowDebugInfo { get; set; }
        public bool LiveForever { get; set; }

        public bool FullScreen { get; set; }

        public string BgmSoundEffect { get; set; }

        public static readonly Settings Default = new Settings
        {
            LiveForever = false,
            NumOfEnemiesPerSecond = 2,
            NumOfLasersPerSecond = 10,
            ShowDebugInfo = false,
            FullScreen = false,
            BgmSoundEffect = "bgm"
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

                    if (readSettings.NumOfLasersPerSecond < 8)
                    {
                        readSettings.NumOfLasersPerSecond = Default.NumOfLasersPerSecond;
                    }

                    if (string.IsNullOrEmpty(readSettings.BgmSoundEffect))
                    {
                        readSettings.BgmSoundEffect = Default.BgmSoundEffect;
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
