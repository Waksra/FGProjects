
using Abilities;
using UnityEngine;

namespace Actor
{
    public class AbilitiesSlot : MonoBehaviour
    {

        [SerializeField] private int maxAbilityCount = 1;

        private int _currentAbility = 0;
        private int _currentAbilityCount = 0;
        private IAbility[] _abilities;

        public int CurrentAbility
        {
            get => _currentAbility;
            set => _currentAbility = Mathf.Clamp(value, 0, _currentAbilityCount - 1);
        }

        public int CurrentAbilityCount => _currentAbilityCount;

        public void Initialize(GameObject owner)
        {
            _abilities = new IAbility[maxAbilityCount];
            foreach (var ability in GetComponentsInChildren<IAbility>())
            {
                ability.Equip(transform, owner);
                _abilities[_currentAbilityCount] = ability;
                _currentAbilityCount++;
            }
        }

        public void Activate()
        {
            if(_currentAbilityCount == 0)
                return;
            
            _abilities[_currentAbility].Activate();
        }

        public void Deactivate()
        {
            if(_currentAbilityCount == 0)
                return;
            
            _abilities[_currentAbility].Deactivate();
        }

        public void AddAbility(IAbility ability, GameObject owner)
        {
            ability.Equip(transform, owner);
            if (_currentAbilityCount == maxAbilityCount)
            {
                _abilities[_currentAbility] = ability;
            }
            else
            {
                _abilities[_currentAbilityCount] = ability;
                _currentAbilityCount++;
            }
        }

        public void NextAbility()
        {
            if(maxAbilityCount <= 1)
                return;
            
            _abilities[_currentAbility].Deactivate();
            _currentAbility++;
            if (_currentAbility > _currentAbilityCount - 1)
                _currentAbility = 0;
        }

        public void PreviousAbility()
        {
            if(maxAbilityCount <= 1)
                return;
            
            _abilities[_currentAbility].Deactivate();
            _currentAbility--;
            if (_currentAbility < 0)
                _currentAbility = _currentAbilityCount - 1;
        }
    }
}