using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Environment.Target
{
    public class TargetPointsComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private TargetComponent _targetComponent;
        [SerializeField] private int _score;
        
        public void Hit(object sender, int value)
        {
            _targetComponent.ShowScore(_score);
        }
    }
}