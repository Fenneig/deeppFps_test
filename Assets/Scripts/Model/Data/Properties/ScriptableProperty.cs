using UnityEngine;

namespace DEEPP.Model.Data.Properties
{
    public class ScriptableProperty<TPropertyType> : ScriptableObject, IObservableProperty<TPropertyType>
    {
        [SerializeField] private TPropertyType _value;
        public event IObservableProperty<TPropertyType>.OnPropertyChanged OnChanged;

        public TPropertyType Value
        {
            get => _value;
            set
            {
                var isSame = _value?.Equals(value) ?? false;
                if (isSame) return;
                var oldValue = _value;
                _value = value;
                OnChanged?.Invoke(_value, oldValue);
            }
        }
    }
}