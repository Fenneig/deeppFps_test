using UnityEngine;

namespace DEEPP.Components.Weapon
{
    public class GunComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _muzzleFireParticle;
        [SerializeField] private int _damageAmount;
        [SerializeField] private GameObject _impactEffect;
        private Camera _camera;

        private const float IMPACT_EFFECT_LIFE_TIME = .5f;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Shoot()
        {
            DoEffects();
            
            if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, float.MaxValue)) return;
            var impactEffect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, IMPACT_EFFECT_LIFE_TIME);
            if (!hit.transform.TryGetComponent(out IDamageable damageable)) return;
            damageable.Damage(_damageAmount);
        }

        private void DoEffects()
        {
            _muzzleFireParticle.Play();
        }
    }
}