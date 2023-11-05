using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{

    Vector2 secondsBetweenSpawnsMinMax = new Vector2(1.2f, 0.4f);
    float nextSpawnTime; 
    float secondsBetweenSpawns; 
    float timeAfterMaxDifficulty = 20f; 

    public GameObject Obstacle;
    Vector2 ScreenhalfSizeWorldUnits;

    float directionToRotateTo; 
    float xPositionToSpawnFrom;
    float obstacleSize;

    float timeAtStart;
    float difficultyPercentage ;

    // Start is called before the first frame update
    void Start()
    {
        timeAtStart = Time.time;
        ScreenhalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        difficultyPercentage = Time.time / (timeAtStart + timeAfterMaxDifficulty); 
        secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.x, secondsBetweenSpawnsMinMax.y, difficultyPercentage);

        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            obstacleSize = Random.Range(0.1f, 2f);

            xPositionToSpawnFrom = Random.Range(-ScreenhalfSizeWorldUnits.x + 0.5f, ScreenhalfSizeWorldUnits.x - 0.5f);

            directionToRotateTo = xPositionToSpawnFrom <= 0 ? Random.Range(0, 20): Random.Range(-20, 00);
            Quaternion rotation = Quaternion.Euler(0, 0, directionToRotateTo);
            Vector2 spawnPosition = new Vector2(xPositionToSpawnFrom, ScreenhalfSizeWorldUnits.y + 0.5f);
            GameObject newBlock = (GameObject) Instantiate(Obstacle, spawnPosition, rotation);

            newBlock.transform.localScale = new Vector2(obstacleSize, obstacleSize);
        }
    }
}
