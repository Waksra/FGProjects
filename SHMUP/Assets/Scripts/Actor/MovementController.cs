using System;
using UnityEngine;

namespace Actor
{
    public class MovementController : MonoBehaviour
    {
        [Range(0, 20)] public float maxSpeedX = 5;
        [Range(0, 20)] public float  moveAccelerationX = 5;
        [Range(0, 20)] public float maxSpeedY = 15;
        [Range(0, 20)] public float moveAccelerationY = 8;
        [Range(0, 20)] public float brakeAcceleration = 4;

        public bool isDirectionDependent;

        [NonSerialized] public bool isBrake;

        private Rigidbody2D _body;
        private Transform _transform;

        [NonSerialized] public Vector2 moveVector;

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
            if(moveVector == Vector2.zero)
                return;

            if (isDirectionDependent)
                velocity = _transform.InverseTransformDirection(velocity);
            
            Vector2 desiredVelocity;
            desiredVelocity.x = (moveVector.x != 0) ? moveVector.x * maxSpeedX : velocity.x;
            desiredVelocity.y = (moveVector.y != 0) ? moveVector.y * maxSpeedY : velocity.y;

            float maxVelocityChangeX = moveAccelerationX * Time.deltaTime;
            float maxVelocityChangeY = moveAccelerationY * Time.deltaTime;
            
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxVelocityChangeX);
            velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxVelocityChangeY);

            if (isDirectionDependent)
                velocity = _transform.TransformDirection(velocity);
        }

        private void Brake(ref Vector2 velocity)
        {
            if(!isBrake || velocity == Vector2.zero)
                return;
            
            float maxSpeedChange = brakeAcceleration * Time.deltaTime;
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, maxSpeedChange);
        }
    }
}
