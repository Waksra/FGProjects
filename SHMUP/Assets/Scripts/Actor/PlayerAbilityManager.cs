
using Abilities;
using UnityEngine;

namespace Actor
{
    public class PlayerAbilityManager : MonoBehaviour
    {
        public AbilitiesSlot weapons;
        public AbilitiesSlot shield;
        public AbilitiesSlot hook;

        private void Start()
        {
            weapons.Initialize(gameObject);
        }

        public void StartFireWeapon()
        {
            weapons.Activate();
        }

        public void StopFireWeapon()
        {
            weapons.Deactivate();
        }

        public void NextWeapon()
        {
            weapons.NextAbility();
        }

        public void PreviousWeapon()
        {
            weapons.PreviousAbility();
        }

        public void EquipWeapon(IAbility weapon)
        {
            weapons.AddAbility(weapon, gameObject);
        }

        public void StartShield()
        {
            shield.Activate();
        }

        public void StopShield()
        {
            shield.Deactivate();
        }

        public void StartHook()
        {
            hook.Activate();
        }

        public void StopHook()
        {
            hook.Deactivate();
        }
}
}