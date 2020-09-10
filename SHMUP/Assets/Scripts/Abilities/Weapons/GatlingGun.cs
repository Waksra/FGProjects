
using Abilities.Projectile;
using UnityEngine;

namespace Abilities.Weapons
{
    public class GatlingGun : MonoBehaviour, IAbility
    {
        public float roundsPerMinute = 100f;
        public ProjectileMover projectile;

        private Transform _transform;

        private delegate Vector2 OwnerVelocity();

        private OwnerVelocity _getOwnerVelocity;

        private void Awake()
        {
            _transform = transform;
        }

        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }

        public void Equip(Transform slot, GameObject owner)
        {
            _transform.parent = slot;
            if (true)
            {
                Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();
                _getOwnerVelocity = () => rb.velocity;
            }
        }
    }
}