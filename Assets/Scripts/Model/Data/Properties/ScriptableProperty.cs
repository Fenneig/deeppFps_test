using UnityEngine;

namespace DEEPP.Model.Data.Properties
{
    public class ObservableProperty<TPropertyType> : ScriptableObject
    {
        [SerializeField] private TPropertyType _value;
        
        public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);
        public event OnPropertyChanged OnChanged;

        public TPropertyType Value
        {
            get => _value;
            set
            {
                var isSame = _value?.Equals(value) ?? false;
                if (isSame) return;
                var oldValue = _value;
                _value = value;
                InvokeChangedEvent(_value, oldValue);
            }
        }

        protected void InvokeChangedEvent(TPropertyType newValue, TPropertyType oldValue)
        {
            OnChanged?.Invoke(newValue, oldValue);
        }
    }
}