using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooler
{
    [CreateAssetMenu(fileName = "NewObjectPooler", menuName = "Pooler/Object Pooler", order = 0)]
    public class ObjectPooler : PoolerBase
    {
        public int initialAmount = 15;
        public int amountCreatedIfEmpty = 5;
        public GameObject objectToPool;

        private List<GameObject> _pooledObjects;

        protected override void Setup()
        {
            _pooledObjects = new List<GameObject>(initialAmount);
            CreateObjects(initialAmount);
        }

        public GameObject RetrieveObject()
        {
            if(!_hasPool)
                Initialize();
            
            if (_pooledObjects.Count == 0)
            {
                CreateObjects(amountCreatedIfEmpty);
                Debug.Log($"{name} pool ran out and created new objects.");
            }

            GameObject obj = _pooledObjects[_pooledObjects.Count - 1];
            _pooledObjects.Remove(obj);

            return obj;
        }

        private void CreateObjects(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(objectToPool, pool);
                obj.gameObject.SetActive(false);
                obj.gameObject.AddComponent<OnDisableCallback>().OnDisableEvent +=
                    () => RePoolObject(obj);
                _pooledObjects.Add(obj);
            }
        }
        
        private void RePoolObject(GameObject obj)
        {
            _pooledObjects.Add(obj);
        }
    }
}