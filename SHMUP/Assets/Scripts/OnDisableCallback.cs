using System;
using UnityEngine;

public class OnDisableCallback : MonoBehaviour
{
    public event Action OnDisableEvent;

    private void OnDisable()
    {
        OnDisableEvent?.Invoke();
    }
}