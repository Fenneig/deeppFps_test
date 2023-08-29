using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class LookComponent : MonoBehaviour
    {
        [field: SerializeField] public float HorizontalSensitivity { get; private set; }
        [field: SerializeField] public float VerticalSensitivity { get; private set; }

        public Vector2 MouseDelta { get; set; }
    }
}