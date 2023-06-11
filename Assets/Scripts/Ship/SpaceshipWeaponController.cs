using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Ship
{
    public class SpaceshipWeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject weaponContainer;
        [SerializeField] private KeyCode fireKey = KeyCode.Space;
        [SerializeField] private KeyCode changeWeaponKey = KeyCode.E;
        private List<Weapon> _weapons;
        private int _currentWeaponIndex = 0;
        

        private void Start()
        {
            // Получаем все компоненты Weapon из контейнера
            Weapon[] weaponComponents = weaponContainer.GetComponentsInChildren<Weapon>();
            _weapons = new List<Weapon>(weaponComponents);

        }
        
        private void Update()
        {
            if (Input.GetKeyDown(fireKey))
            {
                if (_weapons.Count > 0)
                {
                    _weapons[_currentWeaponIndex].Fire(transform);
                }
            }
            if (Input.GetKeyDown(changeWeaponKey))
            {
                ChangeWeapon();
            }
        }
        
        private void ChangeWeapon()
        {
            _currentWeaponIndex++;
            if (_currentWeaponIndex >= _weapons.Count)
            {
                _currentWeaponIndex = 0;
            }
        }
        
    }
}
