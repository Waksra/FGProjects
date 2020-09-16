using UnityEngine;

public class AsteroidPlacer : MonoBehaviour
{
    [Range(0,1)]
    public float threshold;
    public float scale;
    public float step;
    public float range;
    
    public GameObject[] asteroidPrefabs;

    private void Awake()
    {
        for (float x = -range; x <= range; x += step)
        {
            for (float y = -range; y <= range; y += step)
            {
                float perlinX = (x / range * scale) + range;
                float perlinY = (y / range * scale) + range;

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
