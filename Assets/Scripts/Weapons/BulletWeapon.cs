using UnityEngine;

namespace Weapons
{
    public class BulletWeapon : Weapon
    {
        public override void Fire(Transform firePoint)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}
