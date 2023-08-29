using UnityEngine;

namespace DEEPP.Components.Characters
{
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(LookComponent))]
    public class Player : MonoBehaviour
    {
        public MoveComponent MoveComponent { get; private set; }
        public LookComponent LookComponent { get; private set; }

        private void Awake()
        {
            MoveComponent = GetComponent<MoveComponent>();
            LookComponent = GetComponent<LookComponent>();
        }
    }
}