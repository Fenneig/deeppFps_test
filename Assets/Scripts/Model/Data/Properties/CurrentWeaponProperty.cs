using DEEPP.Assets;
using UnityEngine;

namespace DEEPP.Model.Data.Properties
{
    [CreateAssetMenu]
    public class CurrentWeaponProperty : ScriptableProperty<WeaponInfo>
    {
        
        public bool IsReloading { get; set; }

    }
}