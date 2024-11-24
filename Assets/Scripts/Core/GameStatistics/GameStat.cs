using System;
using Unity.VisualScripting;

namespace Core.GameStatistics
{
    [Serializable]
    public class GameStat
    {
        public int LevelNumber;
        public float Time;
        public int Score;
        public bool Victory;
    }
}