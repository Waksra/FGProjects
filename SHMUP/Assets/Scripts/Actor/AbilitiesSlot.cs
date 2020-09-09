using System.Collections.Generic;
using Abilities;
using UnityEngine;

namespace Actor
{
    public class AbilitiesSlot : MonoBehaviour
    {

        private int _currentAbility = 0;
        private List<IAbility> _abilities = new List<IAbility>();

        public int CurrentAbility
        {
            get => _currentAbility;
            set => _currentAbility = Mathf.Clamp(value, 0, _abilities.Count - 1);
        }

        private void Awake()
        {
            foreach (var ability in GetComponentsInChildren<IAbility>())
            {
                ability.Equip(transform);
                _abilities.Add(ability);
            }
        }

        public void Activate()
        {
            if(_abilities.Count == 0)
                return;
            
            _abilities[_currentAbility].Activate();
        }

        public void Deactivate()
        {
            if(_abilities.Count == 0)
                return;
            
            _abilities[_currentAbility].Deactivate();
        }

        public void AddAbility(IAbility ability)
        {
            ability.Equip(transform);
            _abilities.Add(ability);
        }

        public void NextAbility()
        {
            _currentAbility++;
            if (_currentAbility > _abilities.Count - 1)
                _currentAbility = 0;
        }

        public void PreviousAbility()
        {
            _currentAbility--;
            if (_currentAbility < 0)
                _currentAbility = _abilities.Count - 1;
        }
    }
}