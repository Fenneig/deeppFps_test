using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Environment
{
    public class TargetComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _score;
        public void Damage()
        {
            Debug.Log($"Earn {_score} points!");
        }
    }
}