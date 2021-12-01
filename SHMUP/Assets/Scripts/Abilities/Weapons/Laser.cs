using System.Collections;
using UnityEngine;

namespace Abilities.Weapons
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, IAbility
    {
        public float damagePerSecond = 10f;
        public float laserLength = 4;
        public float laserHitWidth = 0.3f;
        public float initialFiringDelay;
        public int lineResolution = 4;

        public LayerMask layerMask;
        
        private bool _isFiring;
        
        private Transform _transform;
        private LineRenderer _lineRenderer;
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _transform = transform;
            
            _lineRenderer = GetComponent<LineRenderer>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        public void Activate()
        {
            if(_isFiring)
                return;

            _isFiring = true;
            _particleSystem.Play(true);
            StartCoroutine(FiringCoroutine());
        }

        public void Deactivate()
        {
            _isFiring = false;
            StopAllCoroutines();
            _lineRenderer.positionCount = 0;
            _particleSystem.Stop(true);
        }

        public void Equip(Transform slot, GameObject owner)
        {
            _transform.parent = slot;
            _transform.localPosition = Vector3.zero;
            _transform.localRotation = Quaternion.identity;
        }

        private IEnumerator FiringCoroutine()
        {
            yield return new WaitForSeconds(initialFiringDelay);
            
            _lineRenderer.positionCount = lineResolution;
            Transform particleTransform = _particleSystem.transform;
            int colliderID = -1;
            Damageable damageable = null;
            
            while (_isFiring)
            {
                RaycastHit2D hit = Physics2D.CircleCast(transform.position, laserHitWidth, 
                    _transform.up, laserLength, layerMask);
                
                Vector3 endPoint;
                if (hit)
                {
                    endPoint = hit.point;
                    particleTransform.position = endPoint;
                    if(!_particleSystem.isPlaying) _particleSystem.Play(true);
                    
                    if (colliderID != hit.collider.GetInstanceID())
                    {
                        colliderID = hit.collider.GetInstanceID();
                        hit.collider.TryGetComponent(out damageable);
                    }
                    damageable?.TakeDamage(damagePerSecond * Time.deltaTime);
                }
                else
                {
                    endPoint = (laserLength * _transform.up) + _transform.position;
                    if (_particleSystem.isPlaying)
                    {
                        _particleSystem.Stop(true);
                        _particleSystem.Clear(false);
                    }
                }
                SetLinePositions(endPoint);
                yield return null;
            }
        }

        private void SetLinePositions(Vector3 endPoint)
        {
            for (int i = 0; i < _lineRenderer.positionCount; i++)
            {
                Vector3 position = Vector3.Lerp(
                    transform.position, 
                    endPoint, 
                    (float)i / (_lineRenderer.positionCount - 1));
                
                _lineRenderer.SetPosition(i, position);
            }
        }
    }
}