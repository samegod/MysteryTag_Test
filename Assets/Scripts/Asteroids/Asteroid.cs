using Additions.Pool;
using SpaceShip;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviourPoolObject
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Fly(Vector2 direction, float speed)
        {
            _rigidbody.velocity = direction * speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Ship ship = other.transform.GetComponent<Ship>();

            if (ship != null)
            {
                ship.TakeDamage();
            }
        }

        public void TakeDamage()
        {
            Push();
        }

        public override void Push()
        {
            AsteroidsPool.Instance.Push(this);
        }
    }
}
