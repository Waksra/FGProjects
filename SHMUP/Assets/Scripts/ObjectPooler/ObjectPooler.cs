using UnityEngine;

namespace ObjectPooler
{
        public abstract class ObjectPooler : ScriptableObject
        {
                protected Transform pool;
                private bool _hasPool;
        
                protected static Transform poolParent;
                private bool _hasPoolParent;

                public virtual void Initialize()
                {
                        if(_hasPool)
                                return;

                        if (!_hasPoolParent)
                        {
                                GameObject parentObj = new GameObject("Object Pools");
                                poolParent = parentObj.transform;
                                _hasPoolParent = true;
                                parentObj.AddComponent<OnDestroyCallback>().OnDestroyEvent +=
                                        () => _hasPoolParent = false;
                        }

                        GameObject obj = new GameObject($"{name} Pool");
                        pool = obj.transform;
                        pool.parent = poolParent;
                        _hasPool = true;
                        obj.AddComponent<OnDestroyCallback>().OnDestroyEvent += 
                                () => _hasPool = false;
                        Setup();
                }

                protected abstract void Setup();
        }
}