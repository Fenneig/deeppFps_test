using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(LookComponent))]
    [RequireComponent(typeof(GunComponent))]
    [RequireComponent(typeof(HealthComponent))]
    public class Player : MonoBehaviour, IDamageable
    {
        public MoveComponent MoveComponent { get; private set; }
        public LookComponent LookComponent { get; private set; }
        public GunComponent GunComponent { get; private set; }
        public HealthComponent HealthComponent { get; private set; }

        private void Awake()
        {
            GetRequiredComponents();
        }

        private void GetRequiredComponents()
        {
            MoveComponent = GetComponent<MoveComponent>();
            LookComponent = GetComponent<LookComponent>();
            GunComponent = GetComponent<GunComponent>();
            HealthComponent = GetComponent<HealthComponent>();
        }

        public void Hit(object sender, int value)
        {
            HealthComponent.ModifyHealthByDelta(-value);
        }
    }
}