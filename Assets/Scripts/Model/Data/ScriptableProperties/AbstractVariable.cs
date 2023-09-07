using UnityEngine;

namespace DEEPP.Model.Data.ScriptableProperties
{
    public class AbstractVariable<T> : ScriptableObject
    {
        [SerializeField] private T _value;

        public T Value
        {
            get => _value;
            set => _value = value;
        }
    }
}