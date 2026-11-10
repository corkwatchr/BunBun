using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BunBun
{
    public static class SettingsManager
    {
        private static readonly string SettingsFilePath =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "BunBun",
                "settings.json");

        public static BunBunSettings Load()
        {
            if (!File.Exists(SettingsFilePath))
            {
                return new BunBunSettings();
            }

            return JsonSerializer.Deserialize<BunBunSettings>(
                       File.ReadAllText(SettingsFilePath))
                   ?? new BunBunSettings();
        }

        public static void Save(
            BunBunSettings settings)
        {
            Directory.CreateDirectory(
                Path.GetDirectoryName(SettingsFilePath)!);

            File.WriteAllText(
                SettingsFilePath,
                JsonSerializer.Serialize(
                    settings,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
        }
    }
}
