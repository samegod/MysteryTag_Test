using UnityEngine;

namespace Progress
{
    public static class ProgressSaveLoad
    {
        private const string LastPassedLevelPrefsName = "LastPassedLevel";
        
        public static int GetLastPassedLevel()
        {
            return PlayerPrefs.GetInt(LastPassedLevelPrefsName);
        }

        public static void SaveLastPassedLevel(int level)
        {
            PlayerPrefs.SetInt(LastPassedLevelPrefsName, level);
        }
    }
}