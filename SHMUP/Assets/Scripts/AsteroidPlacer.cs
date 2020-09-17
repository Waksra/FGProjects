using UnityEngine;

public class AsteroidPlacer : MonoBehaviour
{
    [Range(0,1)]
    public float threshold;
    public float scale;
    public float step;
    public float area = 100;
    public float offsetRange = 10000;
    
    public GameObject[] asteroidPrefabs;

    private void Awake()
    {
        float range = Mathf.Sqrt(area) / 2;
        float offset = Random.Range(range, offsetRange);
        
        for (float x = -range; x <= range; x += step)
        {
            for (float y = -range; y <= range; y += step)
            {
                float perlinX = (x / range * scale) + offset;
                float perlinY = (y / range * scale) + offset;

                float value = Mathf.PerlinNoise(perlinX, perlinY);

                if (value >= threshold)
                {
                    GameObject newAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

                    Instantiate(
                        newAsteroid, 
                        new Vector3(x,y), 
                        Quaternion.Euler(0, 0, Random.Range(0,360)), 
                        transform);   
                }
            }
        }
    }
}
