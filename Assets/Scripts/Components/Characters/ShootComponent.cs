using DEEPP.Components.Weapon;
using DEEPP.Utils;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class ShootComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _impactEffect;
        private Camera _camera;
        private WeaponComponent _weapon;
        private Timer _shootsPerSecondTimer = new();
        private bool _isShooting;

        private const float IMPACT_EFFECT_LIFE_TIME = .5f;
        private const float SECONDS_IN_MINUTE = 60f;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_isShooting && _shootsPerSecondTimer.IsReady) Shoot();
        }

        public void Init(WeaponComponent weapon)
        {
            _weapon = weapon;
            _weapon.OnWeaponChanged += UpdateValues;
            
            UpdateValues();
        }

        private void UpdateValues()
        {
            _shootsPerSecondTimer.Value = SECONDS_IN_MINUTE / _weapon.CurrentWeapon.BulletsPerMinute;
        }

        public void StartShoot()
        {
            _isShooting = true;
        }

        public void StopShoot()
        {
            _weapon.CheckIsNeedToReload();
            _isShooting = false;
        }

        private void Shoot()
        {
            if (!CheckShootPossibility()) return;
            _weapon.CurrentMagazineAmmo.Value--;
            
            DoEffects();
            _shootsPerSecondTimer.Reset();

            if (!_weapon.CurrentWeapon.IsAutomaticFire)
            {
                StopShoot();
            }
            
            CheckHit();
        }

        private bool CheckShootPossibility()
        {
            if (_weapon.IsReloading)
            {
                return false;
            }
            
            if (_weapon.CurrentMagazineAmmo.Value <= 0)
            {
                DoEmptyEffects();
                return false;
            }

            return true;
        }

        private void CheckHit()
        {
            if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, float.MaxValue)) return;

            var impactEffect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, IMPACT_EFFECT_LIFE_TIME);

            if (!hit.transform.TryGetComponent(out IDamageable damageable)) return;
            damageable.Hit(this, 0);
        }

        private void DoEmptyEffects()
        {
            //TODO: magazine jamming sound
        }

        private void DoEffects()
        {
            _weapon.CurrentWeaponModel.MuzzleFireParticle.Play();
        }
    }
}