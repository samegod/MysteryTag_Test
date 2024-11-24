using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Core.LevelSettings
{
    public static class LevelSettingsSaveLoad
    {
        private static LevelSettingsContainer _settingsContainer;
        
        private const string fileName = "LevelSettings.json";
        
        public static void SaveLevelSettings(Settings settings)
        {
            UpdateSettingsContainer();

            var levelSettings = _settingsContainer.settings.FirstOrDefault(x => x.levelNumber == settings.levelNumber);
            if (levelSettings == null)
            {
                _settingsContainer.settings.Add(settings);   
            }
            else
            {
                levelSettings.shipSpeed = settings.shipSpeed;
                levelSettings.asteroidMaxSpeed = settings.asteroidMaxSpeed;
                levelSettings.asteroidMinSpeed = settings.asteroidMinSpeed;
                levelSettings.shipShootDelay = settings.shipShootDelay;
            }
            
            SaveSettingsContainer();
        }

        public static Settings LoadLevelSettings(int levelNumber)
        {
            UpdateSettingsContainer();
            
            return _settingsContainer.settings.FirstOrDefault(x => x.levelNumber == levelNumber);
        }

        private static void UpdateSettingsContainer()
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);

            if (!File.Exists(filePath))
            {
                SaveSettingsContainer();
            }
            
            string jsonClass = File.ReadAllText(filePath);
            _settingsContainer = JsonUtility.FromJson<LevelSettingsContainer>(jsonClass);
        }
 
        private static void SaveSettingsContainer()
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);

            if (_settingsContainer == null)
            {
                _settingsContainer = new LevelSettingsContainer();
            }
            
            string jsonClass = JsonUtility.ToJson(_settingsContainer, true);
            File.WriteAllText(filePath, jsonClass);
        }
    }

    [Serializable]
    public class LevelSettingsContainer
    {
        public List<Settings> settings;
    }
}