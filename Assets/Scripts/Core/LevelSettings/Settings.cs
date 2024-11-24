using System;

namespace Core.LevelSettings
{
    [Serializable]
    public class Settings
    {
        public int levelNumber;
        public float shipSpeed;
        public float shipShootDelay;
        public float asteroidMinSpeed;
        public float asteroidMaxSpeed;
    }
}