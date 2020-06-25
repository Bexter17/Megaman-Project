using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        // Stops the player from being affected by gravity while on ladder
        if (gameObject.CompareTag("Player"))
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        
        if (other.gameObject.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

   void OnTriggerStay2D(Collider2D other)
    {
        if (!(gameObject.tag == "Player"))
            return;

        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, 0));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Stops the player from being affected by gravity while on ladder
        if (gameObject.CompareTag  ("Player"))
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    
   



    }
