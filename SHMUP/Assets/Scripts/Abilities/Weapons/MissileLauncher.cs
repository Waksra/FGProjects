using System.Collections;
using Actor;
using ObjectPooler;
using UnityEngine;

namespace Abilities.Weapons
{
    public class MissileLauncher : MonoBehaviour, IAbility
    {
        public float roundsPerMinute = 100f;
        public float initialFiringDelay = 0.5f;
        public MissilePooler missilePooler;

        private float _timeBetweenRounds;
        private bool _isFiring;
        
        private Transform _transform;

        private delegate Vector2 Vector2Delegate();

        private delegate Transform TransformDelegate();

        private Vector2Delegate _getOwnerVelocity;
        private TransformDelegate _getTarget;

        private void Awake()
        {
            _transform = transform;
            missilePooler.Initialize();

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
            _transform.localRotation = Quaternion.identity;
            
            Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();
            _getOwnerVelocity = () => rb.velocity;
            
            MissileTargetSetter targetSetter = owner.GetComponent<MissileTargetSetter>();
            _getTarget = () => targetSetter.target;
        }

        private IEnumerator FiringCoroutine()
        {
            yield return new WaitForSeconds(initialFiringDelay);

            while (_isFiring)
            {
                missilePooler.FireMissile(_transform, _getTarget.Invoke(), _getOwnerVelocity.Invoke());
                yield return new WaitForSeconds(_timeBetweenRounds);
            }
        }
    }
}
