using DEEPP.Model.Data.Properties;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private IntProperty _hp;
        [SerializeField] private IntProperty _maxHP;
        
        public void Start()
        {
            _hp.Value = _maxHP.Value;
        }

        public void ModifyHealthByDelta(int delta)
        {
            if (_hp.Value <= 0) return;

            if (_hp.Value + delta >= _maxHP.Value) delta = _maxHP.Value - _hp.Value;

            _hp.Value += delta;
        }
    }
}