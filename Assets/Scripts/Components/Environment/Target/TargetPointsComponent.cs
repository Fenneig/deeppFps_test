using DEEPP.Components.Weapon;
using DEEPP.Model.Data.ScriptableProperties;
using UnityEngine;

namespace DEEPP.Components.Environment.Target
{
    public class TargetPointsComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private TargetComponent _targetComponent;
        [SerializeField] private FloatVariable _scoreMultiplier;

        public void Hit(object sender, int value)
        {
            _targetComponent.ShowScore((int) (value * _scoreMultiplier.Value));
        }
    }
}