using Cinemachine;
using UnityEngine;

namespace DEEPP.Input
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        [Header("Sensitivity")]
        [SerializeField] private float _horizontalSensitivity = 10f;
        [SerializeField] private float _verticalSensitivity = 10f;
        [Space, Header("Camera settings")]
        [SerializeField] private float _clampAngle = 80f;
        
        public Vector2 MouseDelta { get; set; }

        private Vector3 _cameraRotation;

        protected override void Awake()
        {
            _cameraRotation = transform.localRotation.eulerAngles;
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!vcam.Follow) return;
            if (stage != CinemachineCore.Stage.Aim) return;
            
            CalculateCameraRotation();
            state.RawOrientation = Quaternion.Euler(-_cameraRotation.y, _cameraRotation.x, 0f);
        }

        private void CalculateCameraRotation()
        {
            _cameraRotation.x += MouseDelta.x * _verticalSensitivity * Time.deltaTime;
            _cameraRotation.y += MouseDelta.y * _horizontalSensitivity * Time.deltaTime;
            _cameraRotation.y = Mathf.Clamp(_cameraRotation.y, -_clampAngle, _clampAngle);
        }
    }
}
