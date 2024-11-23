using SpaceShip.Weapons;
using UnityEngine;

namespace SpaceShip
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ship : MonoBehaviour
    {
        [SerializeField] private Weapon currentWeapon;
        [SerializeField] private float moveSpeed;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Shoot()
        {
            currentWeapon.Shoot();
        }

        public void TakeDamage()
        {
            Debug.Log("Ship damaged");
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
