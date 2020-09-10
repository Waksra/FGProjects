using System;
using UnityEngine;

namespace ObjectPooler
{
        public abstract class ObjectPooler : MonoBehaviour
        {
                private Transform _transform;
        
                private static Transform poolParent;

                public event Action OnDestroyEvent;

                private void Awake()
                {
                        if (poolParent == null)
                                poolParent = new GameObject("Object Pools").transform;

                        _transform = transform;
                        _transform.parent = poolParent;
                }

                private void OnDestroy()
                {
                        OnDestroyEvent?.Invoke();
                }
        }
}