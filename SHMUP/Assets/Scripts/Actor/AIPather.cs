using System;
using UnityEngine;
using Pathfinding;

namespace Actor
{
    [RequireComponent(typeof(Seeker))]
    public class AIPather : MonoBehaviour
    {
        public float repathRate = 0.5f;
        public float nextWaypointDistance = 3f;
        public float rotationSlowdownAngle = 10f;
        
        [NonSerialized] public bool followPath;
        [NonSerialized] public Vector2 targetPosition;

        private int _currentWaypoint;
        private float _lastRepath;
        private bool isEndOfPath;

        private Transform _transform;
        private Seeker _seeker;
        private MovementController _movementController;
        private RotationController _rotationController;

        private Path _path;

        private void Awake()
        {
            _transform = transform;
            _seeker = GetComponent<Seeker>();
            _movementController = GetComponent<MovementController>();
            _rotationController = GetComponent<RotationController>();
        }

        private void OnEnable()
        {
            _seeker.pathCallback += OnPathComplete;
        }

        private void OnDisable()
        {
            _seeker.pathCallback -= OnPathComplete;
        }

        private void OnPathComplete(Path path)
        {
            path.Claim(this);
            if (!path.error)
            {
                _path?.Release(this);
                _path = path;
                _currentWaypoint = 0;
            }
            else
            {
                path.Release(this);
            }
        }

        private void Update()
        {
            if (!followPath) return;

            if (Time.time > _lastRepath + repathRate && _seeker.IsDone())
            {
                _lastRepath = Time.time;
                _seeker.StartPath(_transform.position, targetPosition);
            }

            if (_path == null) return;

            isEndOfPath = false;

            float distanceToWaypoint;

            while (true)
            {
                distanceToWaypoint = Vector2.Distance(_transform.position, _path.vectorPath[_currentWaypoint]);
                if (distanceToWaypoint < nextWaypointDistance)
                {
                    if (_currentWaypoint + 1 < _path.vectorPath.Count)
                        _currentWaypoint++;
                    else
                    {
                        isEndOfPath = true;
                        break;
                    }
                }
                else
                    break;
            }

            Vector2 direction = (_path.vectorPath[_currentWaypoint] - _transform.position).normalized;
            
            float speedFactor = isEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
            _movementController.moveVector = direction * speedFactor;

            float angle = Vector2.SignedAngle(_transform.up, direction);
            float angleSpeedFactor =
                angle <= rotationSlowdownAngle ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
            _rotationController.RotateAmount =  (angle != 0 ? Mathf.Sign(angle) : 0) * angleSpeedFactor;
        }
    }
}