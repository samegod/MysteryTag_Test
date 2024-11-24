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

        private bool _active;
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

        public void SetMoveSpeed(float speed) => moveSpeed = speed;
        
        public void Shoot()
        {
            if (!_active)
                return;
            
            currentWeapon.Shoot();
        }

        public void Enable()
        {
            _active = true;
        }

        public void Disable()
        {
            _active = false;
        }

        public void TakeDamage(float damage)
        {
            if (!_active)
                return;
            
            _health.DecreaseHealth(damage);
            OnHealthChanged?.Invoke();
        }

        private void Die()
        {
            if (!_active)
                return;

            Debug.Log("death");
            OnDeath?.Invoke();
        }

        private void Move()
        {
            if (!_active)
                return;

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
