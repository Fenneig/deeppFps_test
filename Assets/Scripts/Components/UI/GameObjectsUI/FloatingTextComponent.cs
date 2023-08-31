using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DEEPP.Components.UI.GameObjectsUI
{
    public class FloatingTextComponent : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private TextMeshProUGUI _textComponent;
        [Space, Header("Settings")] 
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _fadeDuration;
        [Header("Side-to-Side settings")]
        [SerializeField] private float _sideToSideDurationMin;
        [SerializeField] private float _sideToSideDurationMax;
        [SerializeField] private float _sideToSideDistance;
        [SerializeField] private int _sideToSideLoopsAmount;

        public void AnimateText(string textValue, Color textColor)
        {
            _textComponent.text = textValue;
            _textComponent.color = textColor;

            var floatMoveTween = transform.DOLocalMove(_endPosition, _duration)
                .SetRelative(true);

            var sideToSideDistance = Random.Range(-_sideToSideDistance, _sideToSideDistance);
            var sideToSideDuration = Random.Range(_sideToSideDurationMin, _sideToSideDurationMax);

            var sideToSideTween = transform.DOLocalMoveX(sideToSideDistance, sideToSideDuration)
                .SetRelative(true)
                .SetEase(Ease.InOutSine)
                .SetLoops(_sideToSideLoopsAmount, LoopType.Yoyo);

            _textComponent.DOFade(0f, _fadeDuration)
                .SetDelay(_duration - _fadeDuration)
                .OnComplete(() =>
                {
                    floatMoveTween.Kill();
                    sideToSideTween.Kill();
                    Destroy(gameObject);
                });
        }
    }
}