using UnityEngine;

namespace SpaceShip.Weapons.Blasters
{
    public class Blaster : Weapon
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Bullet bulletPrefab;
        
        public override void Shoot()
        {
            Bullet newBullet = BulletsPool.Instance.Pop(bulletPrefab);
            newBullet.transform.position = shootPoint.position;
            newBullet.Shoot();
        }
    }
}
