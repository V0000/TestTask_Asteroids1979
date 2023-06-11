using UnityEngine;

namespace Weapons
{
    public class LaserWeapon : Weapon
    {
        [SerializeField] private int maxAmmo = 10;
        [SerializeField] private float ammoRegenRate = 1f;

        public delegate void EnemyDestroyed(int amount);

        public static event EnemyDestroyed OnLaserAmmoChanged;


        private int _currentAmmo;
        private float _ammoRegenTimer;

        private void Start()
        {
            _currentAmmo = maxAmmo;
            _ammoRegenTimer = 0f;
        }

        private void Update()
        {
            if (_currentAmmo < maxAmmo)
            {
                _ammoRegenTimer += Time.deltaTime;
                if (_ammoRegenTimer >= ammoRegenRate)
                {
                    OnAmmoChanged(1); //регенерируется один заряд в интервал
                    _ammoRegenTimer = 0f;
                }
            }
        }

        public override void Fire(Transform firePoint)
        {
            if (_currentAmmo > 0)
            {
                GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                OnAmmoChanged(-1); //стреляем и тратим один заряд
            }
        }

        private void OnAmmoChanged(int change)
        {
            _currentAmmo += change;
            OnLaserAmmoChanged?.Invoke(_currentAmmo);
        }
    }
}