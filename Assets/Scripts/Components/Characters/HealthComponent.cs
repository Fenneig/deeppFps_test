using DEEPP.Model.Data.Properties;
using UnityEngine;

namespace DEEPP.Components.Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _maxHP;
        public IntProperty HP { get; private set; }
        public int MaxHP => _maxHP;
        
        public void Start()
        {
            HP = new IntProperty();
            HP.Value = _maxHP;
        }

        public void ModifyHealthByDelta(int delta)
        {
            if (HP.Value <= 0) return;

            if (HP.Value + delta >= _maxHP) delta = _maxHP - HP.Value;

            HP.Value += delta;
        }
    }
}