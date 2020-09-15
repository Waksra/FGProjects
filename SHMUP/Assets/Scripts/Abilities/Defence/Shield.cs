using UnityEngine;

namespace Abilities.Defence
{
    public class Shield : MonoBehaviour, IAbility
    {
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Equip(Transform slot, GameObject owner)
        {
            gameObject.SetActive(false);
            transform.parent = slot;
        }
    }
}
