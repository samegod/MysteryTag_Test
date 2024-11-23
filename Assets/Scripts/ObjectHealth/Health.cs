using System;

namespace ObjectHealth
{
    public class Health
    {
        public event Action OnDeath;

        private float _maxHealth;
        private float _currentHealth;

        public float CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;
        
        public Health(float health)
        {
            _maxHealth = health;
            _currentHealth = health;
        }


        public void SetHealth(float value)
        {
            _currentHealth = value;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
        
        public void SetMaxHealth(float value)
        {
            _maxHealth = value;
        }

        public void DecreaseHealth(float value)
        {
            _currentHealth -= value;

            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void IncreaseHealth(float value)
        {
            _currentHealth += value;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}