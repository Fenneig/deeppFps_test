using DEEPP.Components.Weapon;
using UnityEngine;

namespace DEEPP.Components.Environment
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private int _damageAmount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.Hit(this, _damageAmount);
                Destroy(gameObject);
            }
        }
    }
}