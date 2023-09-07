using DEEPP.Components.Weapon;
using DEEPP.Model.Data.Events;
using DEEPP.Model.Data.ScriptableProperties;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class WeaponComponent : MonoBehaviour
    {
        [Header("GameObject references")]
        [SerializeField] private Transform _weaponSlot;
        [Space, Header("SO References")]
        [SerializeField] private CurrentWeaponVariable _currentWeapon;
        [SerializeField] private IntVariable _currentMagazineAmmo;
        [SerializeField] private IntVariable _reserveAmmo;
        [SerializeField] private IntReference _maxReserveAmmo;
        [SerializeField] private GameEvent _reloadEvent;
        
        private GunModelComponent _currentWeaponModel;
        public CurrentWeaponVariable CurrentWeapon => _currentWeapon;
        public GunModelComponent CurrentWeaponModel => _currentWeaponModel;
        public IntVariable CurrentMagazineAmmo => _currentMagazineAmmo;
        
        
        private void OnEnable()
        {
            InitWeaponStats();
        }

        private void InitWeaponStats()
        {
            EquipWeapon();
            SetMagazineStartValues();
            Reload();
        }

        private void SetMagazineStartValues()
        {
            _currentMagazineAmmo.Value = 0;
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
            
            _reloadEvent.Raise();
            _currentWeapon.IsReloading = false;
        }

        private void EquipWeapon()
        {
            _currentWeaponModel = Instantiate(_currentWeapon.Value.ModelPrefab.gameObject, _weaponSlot)
                .GetComponent<GunModelComponent>();
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