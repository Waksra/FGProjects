using System.Collections;
using UnityEngine;

namespace Abilities.Weapons
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, IAbility
    {
        public float laserLength;
        public float laserWidth;
        public float initialFiringDelay;

        public Color laserColor;

        public LayerMask layerMask;
        
        private bool _isFiring;
        
        private Transform _transform;
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _transform = transform;
            
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.startWidth = laserWidth;
            _lineRenderer.endWidth = laserWidth;
            _lineRenderer.startColor = laserColor;
            _lineRenderer.endColor = laserColor;
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
            _lineRenderer.positionCount = 0;
        }

        public void Equip(Transform slot, GameObject owner)
        {
            _transform.parent = slot;
            _transform.localPosition = Vector3.zero;
        }

        private IEnumerator FiringCoroutine()
        {
            yield return new WaitForSeconds(initialFiringDelay);

            _lineRenderer.positionCount = 2;
            while (_isFiring)
            {
                RaycastHit2D hit = Physics2D.CircleCast(transform.position, laserWidth, 
                    _transform.up, laserLength, layerMask);
                _lineRenderer.SetPosition(0, _transform.position);
                Vector3 point2;
                if(hit)
                    point2 = (hit.distance * _transform.up) + _transform.position;
                else
                    point2 = (laserLength * _transform.up) + _transform.position;
                
                _lineRenderer.SetPosition(1, point2);
                yield return null;
            }
        }
    }
}