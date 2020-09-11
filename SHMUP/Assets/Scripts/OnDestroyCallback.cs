using System;
using UnityEngine;

public class OnDestroyCallback : MonoBehaviour
{
        public event Action OnDestroyEvent;

        private void OnDestroy()
        {
                OnDestroyEvent?.Invoke();
        }
}