using Cinemachine;
using DEEPP.Components.Characters;
using UnityEngine;

namespace DEEPP.Input
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        [SerializeField] private LookComponent _lookComponent;
        [SerializeField] private float _clampAngle = 80f;
        
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
            var mouseDelta = _lookComponent.MouseDelta;
            _cameraRotation.x += mouseDelta.x * _lookComponent.VerticalSensitivity * Time.deltaTime;
            _cameraRotation.y += mouseDelta.y * _lookComponent.HorizontalSensitivity * Time.deltaTime;
            _cameraRotation.y = Mathf.Clamp(_cameraRotation.y, -_clampAngle, _clampAngle);
        }
    }
}
