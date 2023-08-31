using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(LookComponent))]
    [RequireComponent(typeof(ShootComponent))]
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    public class Player : MonoBehaviour, IDamageable
    {
        public MoveComponent MoveComponent { get; private set; }
        public LookComponent LookComponent { get; private set; }
        public ShootComponent ShootComponent { get; private set; }
        public HealthComponent HealthComponent { get; private set; }
        public WeaponComponent WeaponComponent { get; private set; }

        private void Awake()
        {
            GetRequiredComponents();
            InitComponents();
        }

        private void InitComponents()
        {
            ShootComponent.Init(WeaponComponent);
        }

        private void GetRequiredComponents()
        {
            MoveComponent = GetComponent<MoveComponent>();
            LookComponent = GetComponent<LookComponent>();
            ShootComponent = GetComponent<ShootComponent>();
            HealthComponent = GetComponent<HealthComponent>();
            WeaponComponent = GetComponent<WeaponComponent>();
        }

        public void Hit(object sender, int value)
        {
            HealthComponent.ModifyHealthByDelta(-value);
        }
    }
}