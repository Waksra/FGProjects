using UnityEngine;
using UnityEngine.Events;

public class Killable : MonoBehaviour
{
        public UnityEvent onKill;
        
        public void KillDestroy()
        {
                onKill?.Invoke();
                Destroy(gameObject);
        }

        public void KillDisable()
        {
                onKill?.Invoke();
                gameObject.SetActive(false);
        }
}