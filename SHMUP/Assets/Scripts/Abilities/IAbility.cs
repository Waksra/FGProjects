
using UnityEngine;

namespace Abilities
{
    public interface IAbility
    {
        void Activate();

        void Deactivate();

        void Equip(Transform slot, GameObject owner);
    }
}