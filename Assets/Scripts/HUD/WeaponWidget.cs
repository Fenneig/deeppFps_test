using DEEPP.Model.Data.Properties;
using DEEPP.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DEEPP.HUD
{
    public class WeaponWidget : MonoBehaviour
    {
        [Header("UI references")]
        [SerializeField] private Image _weaponImage;
        [SerializeField] private TextMeshProUGUI _currentAmmoText;
        [SerializeField] private TextMeshProUGUI _reserveAmmoText;
        [Space, Header("SO references")]
        [SerializeField] private IntProperty _currentAmmo;
        [SerializeField] private IntProperty _reserveAmmo;
        [SerializeField] private CurrentWeaponProperty _weapon;

        private Timer _reloadTime;
        
        private void Start()
        {
            _weaponImage.sprite = _weapon.Value.Sprite;
            _reloadTime = _weapon.Value.ReloadTime;

            _currentAmmo.OnChanged += UpdateCurrentAmmo;
            _reserveAmmo.OnChanged += UpdateReserveAmmo;
            
            UpdateCurrentAmmo(_currentAmmo.Value, 0);
            UpdateReserveAmmo(_reserveAmmo.Value, 0);
        }

        private void Update()
        {
            if (!_weapon.IsReloading) return;
            _weaponImage.fillAmount = 1 - _reloadTime.RemainingTime / _reloadTime.Value;
        }

        private void UpdateCurrentAmmo(int newValue, int _)
        {
            _currentAmmoText.text = newValue.ToString();
        }
        
        private void UpdateReserveAmmo(int newValue, int _)
        {
            _reserveAmmoText.text = newValue.ToString();
        }

        private void OnDestroy()
        {
            _currentAmmo.OnChanged -= UpdateCurrentAmmo;
            _reserveAmmo.OnChanged -= UpdateReserveAmmo;
        }
    }
}