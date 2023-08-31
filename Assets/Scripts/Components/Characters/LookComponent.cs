using Cinemachine;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class LookComponent : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _verticalClamp;

        public Vector2 MouseDelta { get; set; }

        private float _cameraVerticalRotation;

        private void LateUpdate()
        {
            HandleCameraRotation();
            HandleTransformRotation();
        }

        private void HandleCameraRotation()
        {
            _cameraVerticalRotation -= MouseDelta.y * Time.deltaTime * _sensitivity;
            _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -_verticalClamp, _verticalClamp);
            _camera.transform.localRotation = Quaternion.Euler(_cameraVerticalRotation, 0f, 0f);
        }

        private void HandleTransformRotation()
        {
            transform.Rotate(Vector3.up * MouseDelta.x * Time.deltaTime * _sensitivity);
        }
    }
}