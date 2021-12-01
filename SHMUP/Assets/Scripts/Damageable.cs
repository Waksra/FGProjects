using System;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
        public float maxHealth = 1;
        
        public UnityEvent onDamageTaken;
        public UnityEvent onHealthZero;

        private float _currentHealth;

        private void OnEnable()
        {
                _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
                _currentHealth -= damage;
                onDamageTaken?.Invoke();
                if (_currentHealth <= 0)
                        onHealthZero?.Invoke();
        }
}