using Asteroids;
using SpaceShip;
using UI.GamePanel;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Ship playerShip;
        [SerializeField] private InfoPanel panel;
        [SerializeField] private AsteroidsContainer asteroidsContainer;

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
        }

        private void Victory()
        {
            
        }
        
        private void Defeat()
        {
            
        }

        private void PlayerDamaged()
        {
            panel.SetHealth((int)playerShip.CurrentHealth);
        }

        private void AsteroidDestroyed()
        {
            _currentScore++;
            panel.SetScore(_currentScore);
        }
    }
}
