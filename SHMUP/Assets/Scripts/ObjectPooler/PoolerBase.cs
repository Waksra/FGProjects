using UnityEngine;

namespace ObjectPooler
{
        public abstract class PoolerBase : ScriptableObject
        {
                protected Transform pool;
                protected bool _hasPool;

                public void Initialize()
                {
                        if(_hasPool)
                                return;

                        GameObject obj = new GameObject($"{name} Pool");
                        pool = obj.transform;
                        _hasPool = true;
                        obj.AddComponent<OnDestroyCallback>().OnDestroyEvent += 
                                () => _hasPool = false;
                        Setup();
                }

                protected abstract void Setup();
        }
}