using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletGrab : MonoBehaviour
{
    float nextSpawnTime=5f;
    float secondsBetweenSpawns = 12f;
    float xPositionToSpawnFrom;
    Vector2 ScreenhalfSizeWorldUnits;
    public GameObject BulletObject;

    // Start is called before the first frame update
    void Start()
    {
        ScreenhalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            xPositionToSpawnFrom = Random.Range(-ScreenhalfSizeWorldUnits.x + 0.5f, ScreenhalfSizeWorldUnits.x - 0.5f);
            Vector2 spawnPosition = new Vector2(xPositionToSpawnFrom, ScreenhalfSizeWorldUnits.y + 0.5f);

            Instantiate(BulletObject, spawnPosition, Quaternion.identity);
        }
    }
}
