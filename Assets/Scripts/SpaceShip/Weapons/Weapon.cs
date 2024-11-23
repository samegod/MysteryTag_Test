using UnityEngine;

namespace SpaceShip.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public abstract void Shoot();
    }
}
