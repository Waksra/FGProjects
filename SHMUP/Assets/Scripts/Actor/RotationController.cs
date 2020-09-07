using System;
using UnityEngine;

namespace Actor
{
    public class RotationController : MonoBehaviour
    {
        [Range(0, 10)] public float rotationSpeed;
        public float RotateAmount{set => _desiredAngularVelocity = value}

        private float _desiredAngularVelocity;

        private Rigidbody2D _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float angularVelocity = _body.angularVelocity;
            angularVelocity = Mathf.MoveTowards(angularVelocity, )
        }
    }
}