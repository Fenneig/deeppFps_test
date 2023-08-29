using DEEPP.Components.Characters;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DEEPP.Input
{
    [RequireComponent(typeof(Player))]
    public class PlayerInputReader : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        [UsedImplicitly]
        public void OnMove(InputAction.CallbackContext context)
        {
            _player.MoveComponent.SetMoveDirection(context.ReadValue<Vector2>());
        }

        [UsedImplicitly]
        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.started) Debug.Log("Shoot");
        }

        [UsedImplicitly]
        public void OnLook(InputAction.CallbackContext context)
        {
            _player.LookComponent.MouseDelta = context.ReadValue<Vector2>();
        }
    }
}
