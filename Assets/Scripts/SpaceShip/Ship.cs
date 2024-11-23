using System;
using Damageables;
using ObjectHealth;
using SpaceShip.Weapons;
using UnityEngine;

namespace SpaceShip
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ship : MonoBehaviour, IDamageable
    {
        public event Action OnDeath;
        public event Action OnHealthChanged;
        
        public DamageableType Type => DamageableType.Player;
        
        [SerializeField] private float health;
        [SerializeField] private Weapon currentWeapon;
        [SerializeField] private float moveSpeed;

        private Rigidbody2D _rigidbody;
        private Health _health;

        public float CurrentHealth => _health.CurrentHealth;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _health = new Health(health);
            _health.OnDeath += Die;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Shoot()
        {
            currentWeapon.Shoot();
        }

        public void TakeDamage(float damage)
        {
            _health.DecreaseHealth(damage);
            OnHealthChanged?.Invoke();
        }

        private void Die()
        {
            Debug.Log("death");
            OnDeath?.Invoke();
        }

        private void Move()
        {
            Vector2 moveDirection;
            moveDirection.x = SimpleInput.GetAxis("Horizontal");
            moveDirection.y = SimpleInput.GetAxis("Vertical");
            
            if (moveDirection == Vector2.zero)
                return;
            
            Vector2 newPosition = transform.position;
            newPosition += moveDirection * (moveSpeed * Time.fixedDeltaTime);
            
            _rigidbody.MovePosition(newPosition);
        }
    }
}
