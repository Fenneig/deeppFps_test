using DEEPP.Components.Weapon;
using DEEPP.Model.Data.ScriptableProperties;
using UnityEngine;

namespace DEEPP.Components.Environment
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private IntVariable _damageAmount;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out IDamageable damageable)) return;
            
            damageable.Hit(this, _damageAmount.Value);
            Destroy(gameObject);
        }
    }
}