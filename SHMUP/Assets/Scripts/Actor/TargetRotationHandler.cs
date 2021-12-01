using UnityEngine;

namespace Actor
{
    [RequireComponent(typeof(RotationController))]
    public class TargetRotationHandler : MonoBehaviour
    {
        private Transform _transform;
        private RotationController _rotationController;

        private void Awake()
        {
            _transform = transform;
            _rotationController = GetComponent<RotationController>();
        }

        private void HandleRotation(Vector2 target)
        {
            Vector2 facingDirection = _transform.up;
            Vector2 directionToTarget = target - (Vector2)_transform.position;

            float angle = Vector2.SignedAngle(facingDirection, directionToTarget);
        }
    }
}
