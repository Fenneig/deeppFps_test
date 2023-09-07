using DEEPP.Model.Data.Events;
using DEEPP.Model.Data.ScriptableProperties;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private IntVariable _hp;
        [SerializeField] private IntReference _maxHPRef;
        [SerializeField] private GameEvent _damagedEvent;
        [SerializeField] private GameEvent _deathEvent;
        
        public void Start()
        {
            _hp.Value = _maxHPRef.Value;
        }

        public void ModifyHealthByDelta(int delta)
        {
            if (_hp.Value <= 0) return;

            if (_hp.Value + delta >= _maxHPRef.Value) delta = _maxHPRef.Value - _hp.Value;

            _hp.Value += delta;
            
            if (_hp.Value <= 0 && _deathEvent != null) _deathEvent.Raise();
            else if (delta < 0 && _damagedEvent != null) _damagedEvent.Raise();
        }
    }
}