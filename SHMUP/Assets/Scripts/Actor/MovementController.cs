using System;
using UnityEngine;

namespace Actor
{
    public class MovementController : MonoBehaviour
    {
        [Range(0, 20)] public float maxSpeed = 10;
        [Range(0, 20)] public float moveAcceleration = 10;
        [Range(0, 20)] public float brakeAcceleration = 10;

        public bool isDirectionDependent;

        [NonSerialized] public bool IsBrake;

        private Rigidbody2D _body;
        private Transform _transform;

        [NonSerialized] public Vector2 MoveVector;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
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
            //TODO: Velocity buildup if braking.
            if(MoveVector == Vector2.zero)
                return;

            Vector2 desiredVelocity = MoveVector * maxSpeed;
            if (isDirectionDependent)
                desiredVelocity = _transform.TransformDirection(desiredVelocity);
            
            float maxVelocityChange = moveAcceleration * Time.deltaTime;
            velocity = Vector2.MoveTowards(velocity, desiredVelocity, maxVelocityChange);
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
