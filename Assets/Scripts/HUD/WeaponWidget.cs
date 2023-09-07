using DEEPP.Model.Data.ScriptableProperties;
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
        [SerializeField] private IntVariable _currentAmmo;
        [SerializeField] private IntVariable _reserveAmmo;
        [SerializeField] private CurrentWeaponVariable _weapon;

        private Timer _reloadTime;
        
        private void Start()
        {
            _weaponImage.sprite = _weapon.Value.Sprite;
            _reloadTime = _weapon.Value.ReloadTime;
        }

        private void Update()
        {
            if (!_weapon.IsReloading) return;
            _weaponImage.fillAmount = 1 - _reloadTime.RemainingTime / _reloadTime.Value;
        }

        public void UpdateCurrentAmmo()
        {
            _currentAmmoText.text = _currentAmmo.Value.ToString();
        }
        
        public void UpdateReserveAmmo()
        {
            _reserveAmmoText.text = _reserveAmmo.Value.ToString();
        }
    }
}