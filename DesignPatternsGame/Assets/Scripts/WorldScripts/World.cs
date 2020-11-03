using System.Collections;
using UnityEngine;
using FactoryScripts;
using ActorScripts;

namespace WorldScripts
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Vector2Int worldSize;
        [SerializeField] private float maxHeight = 2f;
        [SerializeField] private float heightIncrement = 0.25f;
        [SerializeField] private float perlinScale = 10;
        [Space(10)]
        [SerializeField] private TileFactory tileFactory;
        [SerializeField] private ActorFactory actorFactory;

        private Tile[,] _tiles;

        private void Start()
        {
            GenerateWorld();
            StartCoroutine(DelayedStart());
        }

        private void GenerateWorld()
        {
            float randomOffsetX = Random.Range(0, 10000);
            float randomOffsetY = Random.Range(0, 10000);
            
            _tiles = new Tile[worldSize.x, worldSize.y];
            
            for (int x = 0; x < worldSize.x; x++)
            {
                for (int y = 0; y < worldSize.y; y++)
                {
                    float perlinX = (float)x / worldSize.x * perlinScale + randomOffsetX;
                    float perlinY = (float)y / worldSize.y * perlinScale + randomOffsetY;
                    float height = Mathf.PerlinNoise(perlinX, perlinY) * maxHeight;
                    
                    if (heightIncrement > 0)
                        height = Mathf.Round(height / heightIncrement) * heightIncrement;

                    Tile newTile = tileFactory.GetNewInstance();
                    
                    Transform tileTransform = newTile.transform;
                    tileTransform.position = new Vector3(x,height / 2,y);
                    
                    Vector3 tileScale = tileTransform.localScale;
                    tileScale.y = height;
                    tileTransform.localScale = tileScale;
                    
                    tileTransform.parent = transform;

                    _tiles[x, y] = newTile;
                }
            }
        }

        private void SpawnActors()
        {
            int x = Random.Range(0, worldSize.x);
            int y = Random.Range(0, worldSize.y);

            Tile spawnTile = _tiles[x, y];

            Actor newActor = actorFactory.GetNewInstance();
            newActor.Initialize(this, spawnTile);

            float height = spawnTile.SurfaceHeight + newActor.Height / 2;
            newActor.transform.position = new Vector3(x, height, y);
        }

        IEnumerator DelayedStart()
        {
            yield return null;
            SpawnActors();
        }

        public Tile GetTileAt(int x, int y)
        {
            if (x >= 0 && x < worldSize.x && y >= 0 && y < worldSize.y)
                return _tiles[x, y];
            
            return null;
        }
    }
}
