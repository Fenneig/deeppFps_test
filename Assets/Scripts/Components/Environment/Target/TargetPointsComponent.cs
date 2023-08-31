using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Environment.Target
{
    public class TargetPointsComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private TargetComponent _targetComponent;
        [SerializeField] private int _score;
        
        public void Hit()
        {
            _targetComponent.ShowScore(_score);
        }
    }
}