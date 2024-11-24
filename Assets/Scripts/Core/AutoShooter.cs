using SpaceShip;
using UnityEngine;

namespace Core
{
    public class AutoShooter : MonoBehaviour
    {
        [SerializeField] private Ship ship;
        [SerializeField] private float shotDelay;
        [SerializeField] private bool isWorking;
        
        private float _currentTimePassed;

        public bool IsWorking
        {
            get => isWorking;
            set => isWorking = value;
        }

        private void Update()
        {
            if (!isWorking)
                return;
            
            _currentTimePassed += Time.deltaTime;

            if (_currentTimePassed >= shotDelay)
            {
                Shoot();
            }
        }

        public void SetShootDelay(float delay) => shotDelay = delay;

        private void Shoot()
        {
            ship.Shoot();
            _currentTimePassed = 0;
        }
    }
}
