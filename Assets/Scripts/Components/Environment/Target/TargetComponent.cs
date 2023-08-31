using System;
using System.Collections.Generic;
using DEEPP.Components.UI.GameObjectsUI;
using UnityEngine;

namespace DEEPP.Components.Environment.Target
{
    public class TargetComponent : MonoBehaviour
    {
        [SerializeField] private Canvas _pointsShowCanvas;
        [SerializeField] private FloatingTextComponent _pointsTextComponentPrefab;
        [SerializeField] private List<NumericalColor> _numericalColors;

        private void Awake()
        {
            _pointsShowCanvas.worldCamera = Camera.main;
        }

        public void ShowScore(int score)
        {
            Color targetColor = Color.white;
            foreach (var numericalColor in _numericalColors)
            {
                if (score >= numericalColor.MinValue) targetColor = numericalColor.MatchingColor;
                else break;
            }
            var pointsText = Instantiate(_pointsTextComponentPrefab, _pointsShowCanvas.transform);
            pointsText.AnimateText(score.ToString(), targetColor);
        }
    }

    [Serializable]
    public class NumericalColor
    {
        [field: SerializeField] public int MinValue { get; private set; }
        [field: SerializeField] public Color MatchingColor { get; private set; }
    }
}