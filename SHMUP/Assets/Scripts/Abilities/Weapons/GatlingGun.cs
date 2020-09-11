
using System;
using System.Collections;
using ObjectPooler;
using UnityEngine;

namespace Abilities.Weapons
{
    public class GatlingGun : MonoBehaviour, IAbility
    {
        public float roundsPerMinute = 100f;
        public float initialFiringDelay = 0.5f;
        public ProjectilePooler projectilePooler;

        private float _timeBetweenRounds;
        private bool _isFiring;
        
        private Transform _transform;

        private delegate Vector2 OwnerVelocity();

        private OwnerVelocity _getOwnerVelocity;

        private void Awake()
        {
            _transform = transform;
            projectilePooler.Initialize();

            _timeBetweenRounds = 60 / roundsPerMinute;
        }

        public void Activate()
        {
            if(_isFiring)
                return;

            _isFiring = true;
            StartCoroutine(FiringCoroutine());
        }

        public void Deactivate()
        {
            _isFiring = false;
            StopAllCoroutines();
        }

        public void Equip(Transform slot, GameObject owner)
        {
            _transform.parent = slot;
            _transform.localPosition = Vector3.zero;
            if (true)
            {
                Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();
                _getOwnerVelocity = () => rb.velocity;
            }
        }

        private IEnumerator FiringCoroutine()
        {
            yield return new WaitForSeconds(initialFiringDelay);

            while (_isFiring)
            {
                projectilePooler.FireProjectile(_transform, _getOwnerVelocity.Invoke());
                yield return new WaitForSeconds(_timeBetweenRounds);
            }
        }
    }
}