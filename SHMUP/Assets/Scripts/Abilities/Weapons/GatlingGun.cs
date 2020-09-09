using System;
using UnityEngine;

namespace Abilities.Weapons
{
    public class GatlingGun : MonoBehaviour, IAbility
    {
        public float roundsPerMinute = 100f;
        public GameObject projectile;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Activate()
        {
            Instantiate(projectile, _transform.position, _transform.rotation);
        }

        public void Deactivate()
        {
            
        }

        public void Equip(Transform slot)
        {
            _transform.parent = slot;
        }
    }
}