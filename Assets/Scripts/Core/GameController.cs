using Asteroids;
using Core.GameStatistics;
using DataTransfering;
using MonoTimer;
using Progress;
using SpaceShip;
using UI.GameMenus;
using UI.GamePanel;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int targetScoreForVictory;
        [SerializeField] private GameMenus menus;
        [SerializeField] private Ship playerShip;
        [SerializeField] private InfoPanel panel;
        [SerializeField] private AsteroidsSpawner spawner;
        [SerializeField] private AsteroidsContainer asteroidsContainer;
        [SerializeField] private Timer timer;

        private int _currentScore;
        
        private void OnEnable()
        {
            playerShip.OnDeath += Defeat;
            playerShip.OnHealthChanged += PlayerDamaged;
            asteroidsContainer.OnAsteroidKilled += AsteroidDestroyed;

        }

        private void OnDisable()
        {
            playerShip.OnDeath -= Defeat;
            playerShip.OnHealthChanged -= PlayerDamaged;
            asteroidsContainer.OnAsteroidKilled -= AsteroidDestroyed;
        }

        private void Start()
        {
            panel.SetHealth((int)playerShip.CurrentHealth);
            panel.SetScore(_currentScore);
            
            StartGame();
        }

        private void StartGame()
        {
            spawner.Enable();
            playerShip.Enable();
            timer.StartCounting();
        }

        private void StopGame(bool victory = false)
        {
            spawner.Disable();
            playerShip.Disable();
            timer.StopCounting();
            
            GameStatsSaveLoad.SaveStat(DataTransfer.Instance.CurrentLevel, timer.TimePassed, _currentScore, victory);
        }

        private void Victory()
        {
            menus.ShowVictoryMenu();
            StopGame(true);
            ProgressSaveLoad.SaveLastPassedLevel(DataTransfer.Instance.CurrentLevel);
        }
        
        private void Defeat()
        {
            menus.ShowDefeatMenu();
            StopGame();
        }

        private void PlayerDamaged()
        {
            panel.SetHealth((int)playerShip.CurrentHealth);
        }

        private void AsteroidDestroyed()
        {
            _currentScore++;
            panel.SetScore(_currentScore);

            if (_currentScore >= targetScoreForVictory)
            {
                Victory();
            }
        }
    }
}
