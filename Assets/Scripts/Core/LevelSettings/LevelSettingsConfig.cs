using Additions.DataStructures;
using UnityEngine;

namespace Core.LevelSettings
{
    [CreateAssetMenu(menuName = "LevelSettingsConfig", fileName = "LevelSettingsConfig", order = 0)]
    public class LevelSettingsConfig : ScriptableObject
    {
        [SerializeField] private FloatRange shipSpeed;
        [SerializeField] private FloatRange shipShootDelay;
        [SerializeField] private FloatRange asteroidMinSpeed;
        [SerializeField] private FloatRange asteroidMaxSpeed;

        public FloatRange ShipSpeed => shipSpeed;
        public FloatRange ShipShootDelay => shipShootDelay;
        public FloatRange AsteroidMinSpeed => asteroidMinSpeed;
        public FloatRange AsteroidMaxSpeed => asteroidMaxSpeed;
    }
}