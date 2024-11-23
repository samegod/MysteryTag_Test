using Additions.Pool;
using Asteroids;
using Damageables;
using UnityEngine;

namespace SpaceShip.Weapons.Blasters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviourPoolObject
    {
        [SerializeField] private float damage;
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IDamageable asteroid = other.transform.GetComponent<Asteroid>();

            if (asteroid != null)
            {
                asteroid.TakeDamage(damage);
                Push();
            }
        }

        public void Shoot()
        {
            _rigidbody.velocity = Vector2.up * speed;
        }

        public override void Push()
        {
            BulletsPool.Instance.Push(this);
        }
    }
}
