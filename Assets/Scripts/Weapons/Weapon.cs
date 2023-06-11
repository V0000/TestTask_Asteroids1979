using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public abstract void Fire(Transform firePoint);
    }
}
