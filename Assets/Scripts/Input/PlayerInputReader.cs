using DEEPP.Components.Characters;
using JetBrains.Annotations;
using UnityEditor;
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
            if (context.started) _player.ShootComponent.StartShoot();
            if (context.canceled) _player.ShootComponent.StopShoot();
        }

        [UsedImplicitly]
        public void OnLook(InputAction.CallbackContext context)
        {
            _player.LookComponent.MouseDelta = context.ReadValue<Vector2>();
        }

        [UsedImplicitly]
        public void OnReload(InputAction.CallbackContext context)
        {
            _player.WeaponComponent.Reload();
        }

        [UsedImplicitly]
        public void OnExit(InputAction.CallbackContext context)
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}