﻿using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooler
{
    [CreateAssetMenu(fileName = "NewProjectilePooler", menuName = "Pooler/Projectile Pooler", order = 0)]
    public class ProjectilePooler : ObjectPooler
    {
        public int initialAmount = 15;
        public int amountCreatedIfEmpty = 5;
        public Projectile projectileToPool;

        private Stack<Projectile> _pooledProjectiles;

        protected override void Setup()
        {
            _pooledProjectiles = new Stack<Projectile>(initialAmount);
            CreateProjectiles(initialAmount);
        }

        public void FireProjectile(Transform origin, Vector2 addedVelocity)
        {
            if (_pooledProjectiles.Count == 0)
            {
                CreateProjectiles(amountCreatedIfEmpty);
                Debug.Log($"{name} pool ran out and created new projectiles.");
            }

            Projectile projectile = _pooledProjectiles.Pop();
            projectile.gameObject.SetActive(true);
            projectile.Fire(origin,addedVelocity);
        }

        private void CreateProjectiles(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Projectile projectile = Instantiate(projectileToPool, pool);
                projectile.gameObject.SetActive(false);
                projectile.gameObject.AddComponent<OnDisableCallback>().OnDisableEvent +=
                    () => RePoolProjectile(projectile);
                _pooledProjectiles.Push(projectile);
            }
        }

        private void RePoolProjectile(Projectile projectile)
        {
            _pooledProjectiles.Push(projectile);
        }
    }
}