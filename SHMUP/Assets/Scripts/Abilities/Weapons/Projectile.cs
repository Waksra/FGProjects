
using UnityEngine;

namespace Abilities.Weapons
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Projectile")]
    public class Projectile : ScriptableObject
    {
        public float initialVelocity;
        public bool relativeVelocity;

        public float maxRange;

        private bool hasPool;
        private ObjectPooler.ObjectPooler _pooler;

        public void Initialize()
        {
            if (hasPool) 
                return;
            
            GameObject obj = new GameObject($"{name} Pool");
            _pooler = obj.AddComponent<ObjectPooler.ObjectPooler>();
            _pooler.OnDestroyEvent += () => hasPool = false;
        }

        public void Fire()
        {
            
        }
    }
}
