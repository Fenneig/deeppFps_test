using DEEPP.Model.Data.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DEEPP.HUD
{
    public class HealthWidget : MonoBehaviour
    {
        [SerializeField] private Image _healthValueImage;
        [SerializeField] private TextMeshProUGUI _healthValueText;
        [SerializeField] private IntProperty _hp;
        [SerializeField] private IntProperty _maxHp;
        
        private void Start()
        {
            _hp.OnChanged += UpdateHealth;
            UpdateHealth(_maxHp.Value, 0);
        }

        private void UpdateHealth(int newValue, int _)
        {
            _healthValueText.text = newValue.ToString();
            _healthValueImage.fillAmount = (float) newValue / _maxHp.Value;
        }

        private void OnDestroy()
        {
            _hp.OnChanged -= UpdateHealth;
        }
    }
}