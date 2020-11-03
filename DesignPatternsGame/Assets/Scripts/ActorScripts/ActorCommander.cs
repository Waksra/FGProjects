using UnityEngine;

namespace ActorScripts
{
    public class ActorCommander : MonoBehaviour
    {
        private Actor _actor;

        private void Awake()
        {
            _actor = GetComponent<Actor>();
        }
    }
}