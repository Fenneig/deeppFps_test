using DEEPP.Assets;
using UnityEngine;

namespace DEEPP.Model.Data.Properties
{
    [CreateAssetMenu]
    public class CurrentWeaponProperty : ObservableProperty<WeaponInfo>
    {
        public bool IsReloading { get; set; }
    }
}