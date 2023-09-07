using DEEPP.Assets;
using UnityEngine;

namespace DEEPP.Model.Data.ScriptableProperties
{
    [CreateAssetMenu(fileName = "Weapon variable", menuName = "Properties/Variables/WeaponVariable")]
    public class CurrentWeaponVariable : AbstractVariable<WeaponInfo>
    {
        public bool IsReloading { get; set; }
    }
}