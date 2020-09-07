using System;
using UnityEngine;

namespace Actor
{
    public class MovementController : MonoBehaviour
    {
        [Range(0, 20)] public float maxSpeed = 10;
        [Range(0, 20)] public float moveAcceleration = 10;
        [Range(0, 20)] public float brakeAcceleration = 10;
        public Vector2 MoveVector
        {
            set => _desiredVelocity = value * maxSpeed;
        }

        [NonSerialized] public bool IsBrake;

        private Vector2 _moveVector;
        private Vector2 _desiredVelocity;
        
        private Rigidbody2D _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector2 velocity = _body.velocity;
            Move(ref velocity);
            Brake(ref velocity);
            _body.velocity = velocity;
        }

        private void Move(ref Vector2 velocity)
        {
            if(_desiredVelocity == Vector2.zero)
                return;

            float maxSpeedChange = moveAcceleration * Time.deltaTime;
            velocity = Vector2.MoveTowards(velocity, _desiredVelocity, maxSpeedChange);
        }

        private void Brake(ref Vector2 velocity)
        {
            if(!IsBrake || velocity == Vector2.zero)
                return;
            
            float maxSpeedChange = brakeAcceleration * Time.deltaTime;
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, maxSpeedChange);
        }
    }
}
