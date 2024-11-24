using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Core.GameStatistics
{
    public static class GameStatsSaveLoad
    {
        private static GameStatsContainer _statsContainer = new();

        private const int MaxStatsSaved = 10;
        private const string FileName = "GameStats.json";

        public static void SaveStat(int level, float time, int score, bool victory)
        {
            GameStat stat = new()
            {
                LevelNumber = level,
                Score = score,
                Time = time,
                Victory = victory
            };
            
            SaveStat(stat);
        }
        
        public static void SaveStat(GameStat stat)
        {
            UpdateSettingsContainer();

            _statsContainer.stats.Add(stat);

            if (_statsContainer.stats.Count > MaxStatsSaved)
            {
                Debug.Log("delete");
                _statsContainer.stats.RemoveAt(0);
            }
            
            SaveSettingsContainer();
        }

        public static List<GameStat> LoadGameStats()
        {
            UpdateSettingsContainer();

            return _statsContainer.stats;
        }

        private static void UpdateSettingsContainer()
        {
            string filePath = Path.Combine(Application.persistentDataPath, FileName);

            if (!File.Exists(filePath))
            {
                SaveSettingsContainer();
            }
            
            string jsonClass = File.ReadAllText(filePath);
            _statsContainer = JsonUtility.FromJson<GameStatsContainer>(jsonClass);
        }
 
        private static void SaveSettingsContainer()
        {
            string filePath = Path.Combine(Application.persistentDataPath, FileName);
            
            string jsonClass = JsonUtility.ToJson(_statsContainer, true);
            File.WriteAllText(filePath, jsonClass);
        }
    }

    [Serializable]
    public class GameStatsContainer
    {
        public List<GameStat> stats= new List<GameStat>();
    }
}