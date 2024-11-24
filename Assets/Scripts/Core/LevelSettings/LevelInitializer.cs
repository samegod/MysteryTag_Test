using DataTransfering;
using SpaceShip;
using UI.GamePanel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.LevelSettings
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private LevelSettingsConfig config;
        [SerializeField] private InfoPanel panel;
        [SerializeField] private AsteroidsSpawner spawner;
        [SerializeField] private Ship playerShip;
        [SerializeField] private AutoShooter shooter;
        
        private void Start()
        {
            var levelNumber = DataTransfer.Instance != null ? DataTransfer.Instance.CurrentLevel : 0;
            
            Settings levelSettings = LevelSettingsSaveLoad.LoadLevelSettings(levelNumber) ?? CreateNewSettings(levelNumber);

            panel.SetLevelNumber(levelNumber);
            spawner.SetMinSpeed(levelSettings.asteroidMinSpeed);
            spawner.SetMaxSpeed(levelSettings.asteroidMaxSpeed);
            playerShip.SetMoveSpeed(levelSettings.shipSpeed);   
            shooter.SetShootDelay(levelSettings.shipShootDelay);
        }

        private Settings CreateNewSettings(int level)
        {
            Settings newSettings = new()
            {
                levelNumber = level,
                shipSpeed = Random.Range(config.ShipSpeed.Min, config.ShipSpeed.Max),
                shipShootDelay = Random.Range(config.ShipShootDelay.Min, config.ShipShootDelay.Max),
                asteroidMinSpeed = Random.Range(config.AsteroidMinSpeed.Min, config.AsteroidMinSpeed.Max),
                asteroidMaxSpeed = Random.Range(config.AsteroidMaxSpeed.Min, config.AsteroidMaxSpeed.Max)
            };

            LevelSettingsSaveLoad.SaveLevelSettings(newSettings);
            
            return newSettings;
        }
    }
}