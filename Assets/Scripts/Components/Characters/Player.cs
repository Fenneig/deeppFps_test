using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(LookComponent))]
    [RequireComponent(typeof(GunComponent))]
    public class Player : MonoBehaviour
    {
        public MoveComponent MoveComponent { get; private set; }
        public LookComponent LookComponent { get; private set; }
        public GunComponent GunComponent { get; private set; }

        private void Awake()
        {
            MoveComponent = GetComponent<MoveComponent>();
            LookComponent = GetComponent<LookComponent>();
            GunComponent = GetComponent<GunComponent>();
        }
    }
}