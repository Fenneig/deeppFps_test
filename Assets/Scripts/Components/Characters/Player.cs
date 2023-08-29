using DEEPP.Input;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public MoveComponent MoveComponent { get; private set; } = null;
        [field: SerializeField] public CinemachinePOVExtension LookComponent { get; private set; } = null;
    }
}