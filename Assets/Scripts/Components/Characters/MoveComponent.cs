using UnityEngine;

namespace DEEPP.Components.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;
        private Vector3 _moveDirection;
        private Vector3 _velocity;
        private bool _isGrounded;

        private const float GRAVITY_SCALE = 9.81f;
        private const float ON_GROUND_VELOCITY = -2f;

        public void SetMoveDirection(Vector2 direction)
        {
            _moveDirection.x = direction.x;
            _moveDirection.z = direction.y;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _isGrounded = _characterController.isGrounded;

            VerticalMovement();
            HorizontalMovement();
        }
        
        private void HorizontalMovement()
        {
            Vector3 fixedMoveDirection = transform.right * _moveDirection.x + transform.forward * _moveDirection.z;
            fixedMoveDirection.Normalize();
            _characterController.Move(fixedMoveDirection * _speed * Time.deltaTime);
        }

        private void VerticalMovement()
        {
            _velocity.y -= GRAVITY_SCALE * Time.deltaTime;
            if (_isGrounded && _velocity.y < 0) _velocity.y = ON_GROUND_VELOCITY;
            _characterController.Move(_velocity * Time.deltaTime);
        }
    }
}