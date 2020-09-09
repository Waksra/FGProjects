using UnityEngine;

namespace Projectile
{
    [CreateAssetMenu(fileName = "NewProjectileType", menuName = "Projectile Type")]
    public class ProjectileType : ScriptableObject
    {
        public float initialVelocity;
        public bool relativeVelocity;

        public float maxRange;
    }
}