using UnityEngine;
using ActorScripts;

namespace WorldScripts
{
    [RequireComponent(typeof(Collider))]
    public class Tile : MonoBehaviour
    {
        private Collider _collider;
        
        private Actor _occupant;

        public float SurfaceHeight => _collider.bounds.max.y;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }
    }
}
