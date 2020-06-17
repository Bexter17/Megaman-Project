using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D myRigidBody;
    public float JumpForce;
    public float speed;
    public bool isGrounded;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public Bullet projectile;
    public SpriteRenderer Megamansprite;

    public float jumpboost = 5.0f;
    public float jumpboostTime = 5.0f;


    private bool isFacingLeft = false;

    Pickups instance;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (JumpForce <= 0)
        {
            JumpForce = 5;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck is not found ");
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool Jump = Input.GetButtonDown("Jump");
        bool Fire1 = Input.GetButtonDown("Fire1");
        float moveValue = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Fire1", Fire1);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);



        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            myRigidBody.velocity = Vector2.zero;

            myRigidBody.AddForce(Vector2.up * JumpForce);


        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        myRigidBody.velocity = new Vector2(horizontalInput * speed, myRigidBody.velocity.y);

        anim.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));

        anim.SetBool("Jump", isGrounded);



        if (horizontalInput > 0 && isFacingLeft || horizontalInput < 0 && !isFacingLeft)
        {
            flip();
        }

        void flip()
        {
            isFacingLeft = !isFacingLeft;

            Megamansprite.flipX = isFacingLeft;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire1 = true;
            Debug.Log("FIRE");
        }

        else Fire1 = false;



        myRigidBody.velocity = new Vector2(moveValue * speed, myRigidBody.velocity.y);







    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            JumpForce += jumpboost;
            StartCoroutine(StopJumpForce());
            Destroy(collision.gameObject);
        }
       
    }

    

    public IEnumerator StopJumpForce()
    {
        yield return new WaitForSeconds(jumpboostTime);
        JumpForce -= jumpboost;
    }


    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy Projectile")
        {
            Destroy(c.gameObject);
            
        }

    }

    
    
}
