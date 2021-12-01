using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
        public int maxEnemies = 4;
        public float timeBetweenSpawns = 5f;
        public Transform enemyTarget;
        public Transform[] spawnTransforms;
        public ObjectPooler.ObjectPooler enemyPool;

        private List<GameObject> _activeEnemies;

        private void Awake()
        {
                enemyPool.Initialize();
                _activeEnemies = new List<GameObject>(maxEnemies);
        }

        private void OnEnable()
        {
                StartCoroutine(SpawnCoroutine());
        }

        private void OnDisable()
        {
                StopAllCoroutines();
        }

        private IEnumerator SpawnCoroutine()
        {
                while (true)
                {
                        for (int i = 0; i < _activeEnemies.Count; i++)
                        {
                                if (!_activeEnemies[i].activeSelf)
                                {
                                        _activeEnemies.RemoveAt(i);
                                        i--;
                                }
                        }
                        
                        if (_activeEnemies.Count < maxEnemies)
                        {
                                GameObject newEnemy = enemyPool.RetrieveObject();

                                Transform spawnTransform = spawnTransforms[Random.Range(0, spawnTransforms.Length - 1)];
                                Transform enemyTransform = newEnemy.transform;
                                enemyTransform.position = spawnTransform.position;
                                enemyTransform.rotation = spawnTransform.rotation;

                                newEnemy.GetComponent<Actor.EnemyBrain>().target = enemyTarget;

                                newEnemy.SetActive(true);
                                _activeEnemies.Add(newEnemy);
                        }

                        yield return new WaitForSeconds(timeBetweenSpawns);
                }
        }
}