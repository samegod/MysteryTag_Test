using System;
using Additions.Pool;
using Damageables;
using ObjectHealth;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviourPoolObject, IDamageable
    {
        public event Action OnKilled;
        public event Action<Asteroid> OnPush;
        
        [SerializeField] private float health;
        [SerializeField] private float damage;
        [SerializeField] private SpriteRenderer image;
        
        private Rigidbody2D _rigidbody;
        private Health _health;

        public DamageableType Type => DamageableType.Asteroid;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _health = new Health(health);
            _health.OnDeath += Die;
        }

        public override void OnPop()
        {
            base.OnPop();
            
            _health.SetHealth(health);
        }

        public void SetImage(Sprite newImage)
        {
            image.sprite = newImage;
        }
        
        public void Fly(Vector2 direction, float speed)
        {
            _rigidbody.velocity = direction * speed;
        }

        public void TakeDamage(float damage)
        {
            _health.DecreaseHealth(damage);
        }

        private void Die()
        {
            OnKilled?.Invoke();
            Push();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            IDamageable target = other.transform.GetComponent<IDamageable>();

            if (target != null && target.Type != DamageableType.Asteroid)
            {
                target.TakeDamage(damage);
                Push();
            }
        }

        public override void Push()
        {
            AsteroidsPool.Instance.Push(this);
            OnPush?.Invoke(this);
        }
    }
}
