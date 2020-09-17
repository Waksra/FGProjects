using System;
using UnityEngine;

namespace Actor
{
    public class EnemyBrain : MonoBehaviour
    {
        public Transform target;
        
        private AIPather _pather;

        private void Start()
        {
            _pather = GetComponent<AIPather>();
            
            _pather.targetPosition = target.position;
            _pather.followPath = true;
        }

        private void Update()
        {
            _pather.targetPosition = target.position;
        }
    }
}