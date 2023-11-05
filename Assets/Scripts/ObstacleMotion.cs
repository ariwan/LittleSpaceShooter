using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMotion : MonoBehaviour
{
    Vector2 minMaxSpeed = new Vector2(5f, 12f);
    float speed;
    float timeGameStarted;
    float timeUntilMaxSpeed = 5f;
    float difficultyPercentage; 
    float currentTime;

    GameObject ScoreSystem;
    ScoreSystemScript ScoreSystemScript;

    private void Start()
    {
        timeGameStarted = Time.time;

        ScoreSystem = GameObject.Find("ScoreSystem");
        ScoreSystemScript = ScoreSystem.GetComponent<ScoreSystemScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time; 
        difficultyPercentage = currentTime / (timeGameStarted+timeUntilMaxSpeed);
        speed = Mathf.Lerp(minMaxSpeed.x, minMaxSpeed.y, difficultyPercentage);
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(transform.position.y < -7)
        {
            Destroy(gameObject);
            ScoreSystemScript.UpdateScore();
        }
    }
}
