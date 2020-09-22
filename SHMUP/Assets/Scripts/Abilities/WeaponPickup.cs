using Actor;
using UnityEngine;

namespace Abilities
{
    public class WeaponPickup : MonoBehaviour
    {
        public GameObject weaponToEquip;
        public LayerMask layerForPickup;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ( layerForPickup == (layerForPickup | (1 << other.gameObject.layer)))
            {
                IAbility newWeapon = Instantiate(weaponToEquip).GetComponent<IAbility>();
                other.GetComponent<PlayerAbilityManager>().EquipWeapon(newWeapon);
                Destroy(gameObject);
            }
        }
    }
}
