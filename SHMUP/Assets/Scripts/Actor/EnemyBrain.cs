using UnityEngine;

namespace Actor
{
    public class EnemyBrain : MonoBehaviour
    {
        private float rangeToFireMissile = 10;
        
        public Transform target;
        public AbilitiesSlot missileSlot;

        private bool _isFiring;

        private Transform _transform;
        private AIPather _pather;
        private TargetRotationController _rotationController;
        private MissileTargetSetter _missileTargetSetter;

        private void Start()
        {
            _transform = transform;
            
            _pather = GetComponent<AIPather>();
            _rotationController = GetComponent<TargetRotationController>();
            
            _pather.targetPosition = target.position;

            _missileTargetSetter = GetComponent<MissileTargetSetter>();
            _missileTargetSetter.target = target;
            
            missileSlot.Initialize(gameObject);
        }

        private void Update()
        {
            Vector2 targetPosition = target.position;
            
            _pather.targetPosition = targetPosition;
            _pather.FollowPath();
            _rotationController.target = _pather.CurrentWaypointPosition;

            float distanceToTarget = Vector2.Distance(_transform.position, targetPosition);

            if (!_isFiring && distanceToTarget <= rangeToFireMissile)
            {
                missileSlot.Activate();
                _isFiring = true;
            }
            else if (_isFiring && distanceToTarget > rangeToFireMissile)
            {
                missileSlot.Deactivate();
                _isFiring = false;
            }
        }
    }
}