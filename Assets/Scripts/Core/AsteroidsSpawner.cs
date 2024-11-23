using System;
using System.Collections.Generic;
using Additions.Extensions;
using Asteroids;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class AsteroidsSpawner : MonoBehaviour
    {
        public event Action<Asteroid> OnAsteroidSpawned;
        
        [SerializeField] private SpawnCorner leftSpawnCorner;
        [SerializeField] private SpawnCorner rightSpawnCorner;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private Asteroid prefab;
        [SerializeField] private float spawnDelay;
        [SerializeField] private List<Sprite> asteroidImages;

        private float _currentSpawnTime;
        
        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if (_currentSpawnTime >= spawnDelay)
            {
                SpawnAsteroid();
                _currentSpawnTime = 0;
            }
        }

        public void SpawnAsteroid()
        {
            float randomLerpNumber = Random.Range(0f, 1f);

            Asteroid newAsteroid = AsteroidsPool.Instance.Pop(prefab);
            newAsteroid.SetImage(asteroidImages.GetRandomElement());
            
            float angle = Mathf.Lerp(leftSpawnCorner.Angle, rightSpawnCorner.Angle, randomLerpNumber);
            Vector2 position = Vector2.Lerp(leftSpawnCorner.Position.position, rightSpawnCorner.Position.position, randomLerpNumber);

            newAsteroid.transform.position = position;
            newAsteroid.Fly(GetVectorDirection(angle), Random.Range(minSpeed, maxSpeed));
            
            OnAsteroidSpawned?.Invoke(newAsteroid);
        }

        private Vector2 GetVectorDirection(float angle)
        {
            return Quaternion.Euler(0, 0, angle) * Vector2.up;
        }

        private void OnDrawGizmos()
        {
            DrawLine(leftSpawnCorner);
            DrawLine(rightSpawnCorner);
            
            void DrawLine(SpawnCorner spawnCorner)
            {
                Vector3 targetPosition = GetVectorDirection(spawnCorner.Angle) * 8;
                targetPosition += spawnCorner.Position.position;
                
                Gizmos.DrawLine(spawnCorner.Position.position, targetPosition);
            }
        }
    }

    [Serializable]
    public struct SpawnCorner
    {
        public Transform Position;
        public float Angle;
    }
}
