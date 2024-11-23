using Asteroids;
using UnityEngine;

namespace SpaceShip.Weapons.Blasters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Asteroid asteroid = other.transform.GetComponent<Asteroid>();

            if (asteroid)
            {
                asteroid.TakeDamage();
            }
        }

        public void Shoot()
        {
            _rigidbody.velocity = Vector2.up * speed;
        }
    }
}
