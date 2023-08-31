using DEEPP.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DEEPP.HUD
{
    public class HealthWidget : MonoBehaviour
    {
        [SerializeField] private Image _healthValueImage;
        [SerializeField] private TextMeshProUGUI _healthValueText;

        private int _maxHealth;

        private void Start()
        {
            _maxHealth = GameSession.Instance.Player.HealthComponent.MaxHP;
            GameSession.Instance.Player.HealthComponent.HP.OnChanged += UpdateHealth;
            UpdateHealth(_maxHealth, 0);
        }

        private void UpdateHealth(int newValue, int _)
        {
            _healthValueText.text = newValue.ToString();
            _healthValueImage.fillAmount = (float) newValue / _maxHealth;
        }

        private void OnDestroy()
        {
            GameSession.Instance.Player.HealthComponent.HP.OnChanged -= UpdateHealth;
        }
    }
}