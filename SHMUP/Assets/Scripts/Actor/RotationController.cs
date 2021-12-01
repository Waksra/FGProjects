using System;
using UnityEngine;

namespace Actor
{
    public class RotationController : MonoBehaviour
    {
        [Tooltip("Degrees per second")][Range(0, 720)] public float rotationSpeed = 360;
        [Tooltip("Degrees per second per second")][Range(0, 1080)] public float rotationAcceleration = 720;

        public float RotateAmount
        {
            set => _desiredAngularVelocity = value * rotationSpeed;
        }

        private float _desiredAngularVelocity;

        private Rigidbody2D _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float angularVelocity = _body.angularVelocity;
            float maxVelocityChange = rotationAcceleration * Time.deltaTime;
            
            angularVelocity = 
                Mathf.MoveTowards(angularVelocity, _desiredAngularVelocity, maxVelocityChange);
            
            _body.angularVelocity = angularVelocity;
        }
    }
}