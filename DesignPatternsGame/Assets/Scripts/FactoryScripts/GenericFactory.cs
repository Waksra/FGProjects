using UnityEngine;

namespace FactoryScripts
{
    public abstract class GenericFactory<T> : ScriptableObject where T : MonoBehaviour
    {
        [SerializeField] private T prefab;

        public T GetNewInstance()
        {
            return Instantiate(prefab);
        }
    }
}
