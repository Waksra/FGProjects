using Abilities;
using UnityEngine;

namespace Actor
{
    public class PlayerAbilityManager : MonoBehaviour
    {
        public AbilitiesSlot weapons;
        public IAbility shield;
        public IAbility hook;

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
    }
}