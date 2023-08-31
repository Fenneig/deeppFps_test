using System;
using DEEPP.Assets;
using DEEPP.Components.Weapon;
using DEEPP.Model.Data.Properties;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private WeaponInfo _currentWeapon;
        [SerializeField] private Transform _weaponSlot;
        [SerializeField] private IntProperty _reserveAmmo;

        private GunModelComponent _currentWeaponModel;
        private IntProperty _currentMagazineAmmo = new ();
        private bool _isReloading;

        public WeaponInfo CurrentWeapon => _currentWeapon;
        public GunModelComponent CurrentWeaponModel => _currentWeaponModel;
        public IntProperty CurrentMagazineAmmo => _currentMagazineAmmo;
        public IntProperty ReserveAmmo => _reserveAmmo;
        public bool IsReloading => _isReloading;

        public event Action OnWeaponChanged;
        
        private void Awake()
        {
            EquipWeapon();
            Reload();
        }

        private void LoadMagazine()
        {
            if (_reserveAmmo.Value <= 0) return;
            
            if (_currentMagazineAmmo.Value + _reserveAmmo.Value >= _currentWeapon.MagazineCapacity)
            {
                _reserveAmmo.Value -= _currentWeapon.MagazineCapacity - _currentMagazineAmmo.Value;
                _currentMagazineAmmo.Value = _currentWeapon.MagazineCapacity;
            }
            else
            {
                _currentMagazineAmmo.Value += _reserveAmmo.Value;
                _reserveAmmo.Value = 0;
            }

            _isReloading = false;
        }

        private void EquipWeapon()
        {
            _currentWeaponModel = Instantiate(_currentWeapon.ModelPrefab.gameObject, _weaponSlot)
                .GetComponent<GunModelComponent>();
            
            OnWeaponChanged?.Invoke();
        }

        private void Update()
        {
            if (_isReloading && _currentWeapon.ReloadTime.IsReady)
            {
                LoadMagazine();
            }
        }

        public void Reload()
        {
            if (_reserveAmmo.Value <= 0 || _currentMagazineAmmo.Value == _currentWeapon.MagazineCapacity) return;
            //TODO: set animation to animator
            _isReloading = true;
            _currentWeapon.ReloadTime.Reset();
        }

        public void CheckIsNeedToReload()
        {
            if (!_currentWeapon.ReloadTime.IsReady) return;
            if (_currentMagazineAmmo.Value <= 0) Reload();
        }
    }
} 