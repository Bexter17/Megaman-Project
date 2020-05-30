using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Enemy : MonoBehaviour
{
    public int health;
    SpriteRenderer sr;

    Rigidbody2D rb;
    public bool facingLeft;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if(!rb)
        {
            Debug.LogWarning("No Rigidbody 2d");
        }
        if (speed <= 0)
        {
            speed = 5.0f;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.flipX)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            sr.flipX = !sr.flipX;
        }
    }




}
