using DEEPP.Model;
using DEEPP.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DEEPP.HUD
{
    public class WeaponWidget : MonoBehaviour
    {
        [SerializeField] private Image _weaponImage;
        [SerializeField] private TextMeshProUGUI _currentAmmo;
        [SerializeField] private TextMeshProUGUI _reserveAmmo;

        private Timer _reloadTime;
        
        private void Start()
        {
            var weapon = GameSession.Instance.Player.WeaponComponent;
            _weaponImage.sprite = weapon.CurrentWeapon.Sprite;
            _reloadTime = GameSession.Instance.Player.WeaponComponent.CurrentWeapon.ReloadTime;

            GameSession.Instance.Player.WeaponComponent.CurrentMagazineAmmo.OnChanged += UpdateCurrentAmmo;
            GameSession.Instance.Player.WeaponComponent.ReserveAmmo.OnChanged += UpdateReserveAmmo;
            UpdateCurrentAmmo(GameSession.Instance.Player.WeaponComponent.CurrentMagazineAmmo.Value, 0);
            UpdateReserveAmmo(GameSession.Instance.Player.WeaponComponent.ReserveAmmo.Value, 0);
        }

        private void Update()
        {
            if (!GameSession.Instance.Player.WeaponComponent.IsReloading) return;
            _weaponImage.fillAmount = 1 - _reloadTime.RemainingTime / _reloadTime.Value;
        }

        private void UpdateCurrentAmmo(int newValue, int _)
        {
            _currentAmmo.text = newValue.ToString();
        }
        
        private void UpdateReserveAmmo(int newValue, int _)
        {
            _reserveAmmo.text = newValue.ToString();
        }

        private void OnDestroy()
        {
            GameSession.Instance.Player.WeaponComponent.CurrentMagazineAmmo.OnChanged -= UpdateCurrentAmmo;
            GameSession.Instance.Player.WeaponComponent.ReserveAmmo.OnChanged -= UpdateReserveAmmo;
        }
    }
}