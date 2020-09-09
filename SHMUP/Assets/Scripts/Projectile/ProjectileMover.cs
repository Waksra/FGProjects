using UnityEngine;

namespace Projectile
{
    public class ProjectileMover : MonoBehaviour
    {
        public float initialForce;
        public float lifeTime;

        private void Awake()
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * initialForce, ForceMode2D.Impulse);
            
            Destroy(gameObject, lifeTime);
        }

        
    }
}