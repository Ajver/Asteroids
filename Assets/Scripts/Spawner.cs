using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //public GameObject UIPanel;
    public GameObject asteroidPrefab;
    public float nextAsteroidWaitTime = 3.0f;
    public int maxAsteroidsCount = 3;

    private float nextAsteroidTimer;

    private void Start()
    {
        nextAsteroidTimer = nextAsteroidWaitTime;
    }

    void Update()
    {
        nextAsteroidTimer -= Time.deltaTime;

        if (nextAsteroidTimer <= 1.0f)
        {
            nextAsteroidTimer = nextAsteroidWaitTime;

            if (Asteroid.asteroidsCount >= maxAsteroidsCount)
                return;
            
            spawnNextAsteroid();
        }
    }

    void spawnNextAsteroid()
    {
        Asteroid.asteroidsCount++;
        
        Vector3 asteroidPosition = new Vector3(Random.value, Random.value, 0.0f);
        asteroidPosition.x *= MainClass.mapWidthUnits;
        asteroidPosition.y *= MainClass.mapHeightUnits;

        Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);
    }
}
