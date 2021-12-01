using System;
using UnityEngine;

namespace Actor
{
    public class TargetRotationController : MonoBehaviour
    {
        [Range(0, 360)] public float rotationSpeed = 270f;
        public float smoothTime = 0.1f;
        
        [NonSerialized] public Vector2 target;

        private Transform _transform;
        private Rigidbody2D _body;

        private void Awake()
        {
            _transform = transform;
            _body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 direction = target - (Vector2)_transform.position;
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            
            float angularVelocity = _body.angularVelocity;

            Mathf.SmoothDampAngle(_body.rotation, angle, ref angularVelocity, smoothTime, rotationSpeed);

            _body.angularVelocity = angularVelocity;
        }
    }
}
