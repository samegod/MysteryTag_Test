using SpaceShip;
using UI.GamePanel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.LevelSettings
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private int levelNumber;
        [SerializeField] private LevelSettingsConfig config;
        [SerializeField] private InfoPanel panel;
        [SerializeField] private AsteroidsSpawner spawner;
        [SerializeField] private Ship playerShip;
        [SerializeField] private AutoShooter shooter;
        
        private void Start()
        {
            Settings levelSettings = LevelSettingsSaveLoad.LoadLevelSettings(levelNumber);

            if (levelSettings == null)
            {
                levelSettings = CreateNewSettings(levelNumber);
            }
            
            panel.SetLevelNumber(levelNumber);
            spawner.SetMinSpeed(levelSettings.asteroidMinSpeed);
            spawner.SetMaxSpeed(levelSettings.asteroidMaxSpeed);
            playerShip.SetMoveSpeed(levelSettings.shipSpeed);   
            shooter.SetShootDelay(levelSettings.shipShootDelay);
        }

        private Settings CreateNewSettings(int level)
        {
            Settings newSettings = new();

            newSettings.levelNumber = level;
            newSettings.shipSpeed = Random.Range(config.ShipSpeed.Min, config.ShipSpeed.Max);
            newSettings.shipShootDelay = Random.Range(config.ShipShootDelay.Min, config.ShipShootDelay.Max);
            newSettings.asteroidMinSpeed = Random.Range(config.AsteroidMinSpeed.Min, config.AsteroidMinSpeed.Max);
            newSettings.asteroidMaxSpeed = Random.Range(config.AsteroidMaxSpeed.Min, config.AsteroidMaxSpeed.Max);

            LevelSettingsSaveLoad.SaveLevelSettings(newSettings);
            
            return newSettings;
        }
    }
}