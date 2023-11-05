using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    GameObject player;

    GameObject BulletInventory;
    BulletInventoryScript bulletInventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        BulletInventory = GameObject.Find("BulletInventory");
        bulletInventoryScript = BulletInventory.GetComponent<BulletInventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletInventoryScript.BulletInventory >0)
        {
            bullet.transform.position = player.transform.position;
            Instantiate(bullet);
            bulletInventoryScript.BulletInventory -= 1;
        }
    }
}
