using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystemScript : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
