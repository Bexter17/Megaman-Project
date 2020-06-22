using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour
{
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public Enemy_Projectile projectilePrefab;
    public float projectileForce;
    public bool shootLeft;
    public GameObject target = null;
    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public SpriteRenderer HardHatShoot;

    Animator anim;

    public int health;

    public AudioClip damageSFX;
    public AudioClip fireSFX;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(!anim)
        {
            Debug.LogWarning("No animator component found");
        }
        if (!leftSpawnPoint)
        {
            Debug.LogWarning("No Projectile left Spawnpoint");

        }
        if (!rightSpawnPoint)
        {
            Debug.LogWarning("No Projectile right Spawnpoint");
        }
        if (!projectilePrefab)
        {
            Debug.LogWarning("No projectile prefab found");
        }
        
        if (projectileForce == 0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }

        if (!target)
            target = GameObject.FindWithTag("Player");
        shootDirectionCheck();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Shoot()
    {

        anim.SetBool("Shoot", true);
       

        shootDirectionCheck();
        if (shootLeft)
        {
            Instantiate(projectilePrefab, leftSpawnPoint.position,
            Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else
        {
            Instantiate(projectilePrefab, rightSpawnPoint.position,
            Quaternion.Euler(new Vector3(0, 180.0f, 0)));
        }
        anim.SetBool("Shoot", false);

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectiles")
        {
            health--;
                                 
            if (health <= 0)
            {
                Destroy(gameObject);               
            }
            playerAudio.clip = damageSFX;
            playerAudio.Play();
        }
    }

    void shootDirectionCheck()
    {
        // Is target on Left or Right side?
        if (target.transform.position.x < transform.position.x)
            shootLeft = true; // Shoot left
        else
            shootLeft = false; // Shoot right
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (Time.time > timeSinceLastFire + projectileFireRate)
            {
                Shoot();
                timeSinceLastFire = Time.time;

                playerAudio.clip = fireSFX;
                playerAudio.Play();
            }
           
        }
    }

    void flip()
    {
        shootLeft = !shootLeft;

        HardHatShoot.flipX = shootLeft;
   }
}
