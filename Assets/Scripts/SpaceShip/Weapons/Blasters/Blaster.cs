using Unity.Mathematics;
using UnityEngine;

namespace SpaceShip.Weapons.Blasters
{
    public class Blaster : Weapon
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Bullet bulletPrefab;
        
        public override void Shoot()
        {
            Bullet newBullet = Instantiate(bulletPrefab, shootPoint.position, quaternion.identity);
            newBullet.Shoot();
        }
    }
}
