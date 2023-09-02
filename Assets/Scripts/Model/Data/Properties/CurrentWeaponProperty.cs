using DEEPP.Assets;
using UnityEngine;

namespace DEEPP.Model.Data.Properties
{
    [CreateAssetMenu(fileName = "WeaponInfo property", menuName = "Properties/WeaponInfoProperty")]
    public class CurrentWeaponProperty : ObservableProperty<WeaponInfo>
    {
        public bool IsReloading { get; set; }
    }
}