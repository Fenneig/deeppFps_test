using UnityEngine;

namespace DEEPP.Components.Weapon
{
    public class GunModelComponent : MonoBehaviour
    {
        [field:SerializeField] public ParticleSystem MuzzleFireParticle { get; private set; }
    }
}