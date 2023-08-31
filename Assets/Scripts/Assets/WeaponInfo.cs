using DEEPP.Components.Weapon;
using DEEPP.Utils;
using UnityEngine;

namespace DEEPP.Assets
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Assets/Weapon", order = 0)]
    public class WeaponInfo : ScriptableObject
    {
        [SerializeField] private string _name;
        [Space, Header("UI info")] 
        [SerializeField] private Sprite _sprite;
        [Space, Header("Game object info")]
        [SerializeField] private GunModelComponent _modelPrefabPrefab;
        [Space, Header("Gun info")]
        [SerializeField] private int _damage;
        [SerializeField] private int _magazineCapacity;
        [SerializeField] private Timer _reloadTime;
        [SerializeField] private int _bulletsPerMinute;
        [SerializeField] private bool _isAutomaticFire;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public GunModelComponent ModelPrefab => _modelPrefabPrefab;
        public int Damage => _damage;
        public int MagazineCapacity => _magazineCapacity;
        public Timer ReloadTime => _reloadTime;
        public int BulletsPerMinute => _bulletsPerMinute;
        public bool IsAutomaticFire => _isAutomaticFire;
    }
}