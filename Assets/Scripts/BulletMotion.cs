using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion1 : MonoBehaviour
{
    GameObject ScoreSystem;
    ScoreSystemScript ScoreSystemScript;


    int bulletSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem = GameObject.Find("ScoreSystem");
        ScoreSystemScript = ScoreSystem.GetComponent<ScoreSystemScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.tag == "Falling Block")
        {
            Destroy(gameObject) ;
            Destroy(cd.gameObject);
            ScoreSystemScript.UpdateScore();
        }
    }
}
