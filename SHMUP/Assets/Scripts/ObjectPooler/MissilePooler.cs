using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooler
{
    [CreateAssetMenu(fileName = "NewMissilePooler", menuName = "Pooler/Missile Pooler", order = 0)]
    public class MissilePooler : PoolerBase
    {
        public int initialAmount = 15;
        public int amountCreatedIfEmpty = 5;
        public HomingMissile missileToPool;

        private List<HomingMissile> _pooledMissiles;

        protected override void Setup()
        {
            _pooledMissiles = new List<HomingMissile>(initialAmount);
            CreateMissiles(initialAmount);
        }

        public void FireMissile(Transform origin, Transform target, Vector2 addedVelocity)
        {
            if(!_hasPool)
                Initialize();
            
            if (_pooledMissiles.Count == 0)
            {
                CreateMissiles(amountCreatedIfEmpty);
                Debug.Log($"{name} pool ran out and created new missiles.");
            }

            HomingMissile missile = _pooledMissiles[_pooledMissiles.Count - 1];
            _pooledMissiles.Remove(missile);

            missile.gameObject.SetActive(true);
            missile.Fire(origin, target, addedVelocity);
        }

        private void CreateMissiles(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                HomingMissile missile = Instantiate(missileToPool, pool);
                missile.gameObject.SetActive(false);
                missile.gameObject.AddComponent<OnDisableCallback>().OnDisableEvent +=
                    () => RePoolMissile(missile);
                _pooledMissiles.Add(missile);
            }
        }

        private void RePoolMissile(HomingMissile missile)
        {
            _pooledMissiles.Add(missile);
        }
    }
}
