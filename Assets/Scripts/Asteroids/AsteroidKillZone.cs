using System;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidKillZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Asteroid asteroid = other.gameObject.GetComponent<Asteroid>();

            if (asteroid != null)
            {
                asteroid.Push();
            }
        }
    }
}
