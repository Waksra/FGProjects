using System;
using UnityEngine;

namespace Actor
{
    public class RotationController : MonoBehaviour
    {
        [Range(0, 500)] public float rotationSpeed = 200;
        [Range(0, 500)] public float rotationAcceleration = 200;
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