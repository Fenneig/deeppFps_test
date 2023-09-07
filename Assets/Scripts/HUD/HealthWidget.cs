using DEEPP.Model.Data.ScriptableProperties;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DEEPP.HUD
{
    public class HealthWidget : MonoBehaviour
    {
        [Header("Component references")]
        [SerializeField] private Image _healthValueImage;
        [SerializeField] private TextMeshProUGUI _healthValueText;
        [Space, Header("Scriptable object references")]
        [SerializeField] private IntVariable _hp;
        [SerializeField] private IntVariable _maxHp;
        
        [Button("Update health", EButtonEnableMode.Playmode)]
        public void UpdateHealth()
        {
            _healthValueText.text = _hp.Value.ToString();
            _healthValueImage.fillAmount = (float) _hp.Value / _maxHp.Value;
        }
    }
}