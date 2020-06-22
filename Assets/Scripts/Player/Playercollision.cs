using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercollision : MonoBehaviour
{
    public Transform spawnPoint;

    


    // Start is called before the first frame update
    void Start()
    {
       // spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy Projectile")
        {
            GameManager.instance.life -= 1;
            Destroy(collision.gameObject);
           // GameManager.instance.SpawnPlayer(spawnPoint);
           // Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -1.27)
        {
            GameManager.instance.life -= 1;
           // GameManager.instance.SpawnPlayer(spawnPoint);
            Destroy(gameObject);
        }
              
        



    }
}


    




