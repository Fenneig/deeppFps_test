using System;
using DEEPP.Components.Weapon;
using DEEPP.Model.Data.Properties;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class WeaponComponent : MonoBehaviour
    {
        [Header("GameObject references")]
        [SerializeField] private Transform _weaponSlot;
        [Space, Header("SO References")]
        [SerializeField] private CurrentWeaponProperty _currentWeapon;
        [SerializeField] private IntProperty _currentMagazineAmmo;
        [SerializeField] private IntProperty _reserveAmmo;
        [SerializeField] private IntProperty _maxReserveAmmo;
        
        private GunModelComponent _currentWeaponModel;
        public CurrentWeaponProperty CurrentWeapon => _currentWeapon;
        public GunModelComponent CurrentWeaponModel => _currentWeaponModel;
        public IntProperty CurrentMagazineAmmo => _currentMagazineAmmo;
        public event Action OnWeaponChanged;
        
        private void Awake()
        {
            EquipWeapon();
            Reload();
        }

        private void OnEnable()
        {
            _reserveAmmo.Value = _maxReserveAmmo.Value;
        }

        private void LoadMagazine()
        {
            if (_reserveAmmo.Value <= 0) return;
            
            if (_currentMagazineAmmo.Value + _reserveAmmo.Value >= _currentWeapon.Value.MagazineCapacity)
            {
                _reserveAmmo.Value -= _currentWeapon.Value.MagazineCapacity - _currentMagazineAmmo.Value;
                _currentMagazineAmmo.Value = _currentWeapon.Value.MagazineCapacity;
            }
            else
            {
                _currentMagazineAmmo.Value += _reserveAmmo.Value;
                _reserveAmmo.Value = 0;
            }

            _currentWeapon.IsReloading = false;
        }

        private void EquipWeapon()
        {
            _currentWeaponModel = Instantiate(_currentWeapon.Value.ModelPrefab.gameObject, _weaponSlot)
                .GetComponent<GunModelComponent>();
            
            OnWeaponChanged?.Invoke();
        }

        private void Update()
        {
            if (_currentWeapon.IsReloading && _currentWeapon.Value.ReloadTime.IsReady)
            {
                LoadMagazine();
            }
        }

        public void Reload()
        {
            if (_reserveAmmo.Value <= 0 || _currentMagazineAmmo.Value == _currentWeapon.Value.MagazineCapacity) return;
            //TODO: set animation to animator
            _currentWeapon.IsReloading = true;
            _currentWeapon.Value.ReloadTime.Reset();
        }

        public void CheckIsNeedToReload()
        {
            if (!_currentWeapon.Value.ReloadTime.IsReady) return;
            if (_currentMagazineAmmo.Value <= 0) Reload();
        }
    }
} 