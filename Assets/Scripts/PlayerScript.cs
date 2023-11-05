using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject bulletObject;
    BulletInventoryScript bulletObjectScript;

    GameObject bullet;
    public float speed = 7;
    float screenHalfWidthInWordlUnits;


    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWordlUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

        bulletObject = GameObject.Find("BulletInventory");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        bulletObjectScript = bulletObject.GetComponent<BulletInventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;

        transform.Translate(Vector2.right*velocity*Time.deltaTime);

        if(transform.position.x < -screenHalfWidthInWordlUnits+1f)
        {
            transform.position = new Vector2(screenHalfWidthInWordlUnits-1f, transform.position.y);
        }

        if(transform.position.x > screenHalfWidthInWordlUnits-1f)
        {
            transform.position = new Vector2(-screenHalfWidthInWordlUnits+1f, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Falling Block")
        {
            Destroy(gameObject);
        }    

        if(triggerCollider.tag == "BulletGrab")
        {
            Destroy(GameObject.FindGameObjectWithTag("BulletGrab"));
            bulletObjectScript.BulletInventory = 3; 
        }        
    }
}
