using System;
using UnityEngine;

namespace DEEPP.Model.Data.ScriptableProperties
{
    [Serializable]
    public class AbstractReference<T>
    {
        [SerializeField] private bool _useConstant;
        [SerializeField] private T _constantValue;
        [SerializeField] private AbstractVariable<T> _variable;

        public AbstractReference() { }

        public AbstractReference(T value)
        {
            _useConstant = true;
            _constantValue = value;
        }

        public T Value => _useConstant ? _constantValue : _variable.Value;
    }
}