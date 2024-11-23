using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsContainer : MonoBehaviour
    {
        public event Action OnAsteroidKilled;
        
        [SerializeField] private List<Asteroid> asteroids;
        [SerializeField] private AsteroidsSpawner spawner;

        private void OnEnable()
        {
            spawner.OnAsteroidSpawned += AsteroidSpawned;
        }

        private void OnDisable()
        {
            spawner.OnAsteroidSpawned -= AsteroidSpawned;
        }

        private void AsteroidSpawned(Asteroid asteroid)
        {
            asteroid.OnPush += AsteroidPushed;
            asteroid.OnKilled += AsteroidKilled;
            
            asteroids.Add(asteroid);
        }

        private void AsteroidPushed(Asteroid asteroid)
        {
            asteroid.OnPush -= AsteroidPushed;
            asteroid.OnKilled -= AsteroidKilled;

            asteroids.Remove(asteroid);
        }

        private void AsteroidKilled()
        {
            OnAsteroidKilled?.Invoke();
        }
    }
}